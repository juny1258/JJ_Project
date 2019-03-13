using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using GooglePlayGames.BasicApi.SavedGame;
using UnityEngine;
using UnityEngine.UI;

public class PlayCloudDataManager : MonoBehaviour
{
    private static PlayCloudDataManager instance;

    public static PlayCloudDataManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<PlayCloudDataManager>();
            }

            return instance;
        }
    }

    public GameObject LoadSuccessPanel;

    private bool _isProcessing;
    private string _loadedData;
    private const string m_saveFileName = "devil_data";

    private static bool IsAuthenticated
    {
        get { return Social.localUser.authenticated; }
    }

    private static void InitiatePlayGames()
    {
        PlayGamesPlatform.Activate();
        
        var config = new PlayGamesClientConfiguration.Builder()
            // enables saving game progress.
            .EnableSavedGames()
            .Build();

        PlayGamesPlatform.InitializeInstance(config);
        // recommended for debugging:
        PlayGamesPlatform.DebugLogEnabled = false;
    }

    private void Awake()
    {
        InitiatePlayGames();
    }


    private static void Login()
    {
        Social.localUser.Authenticate(success =>
        {
            if (success) return;
            NotificationManager.Instance.SetNotification("Fail Login");
            Debug.Log("Fail Login");
        });
    }


    private void ProcessCloudData(byte[] cloudData)
    {
        if (cloudData == null)
        {
            NotificationManager.Instance.SetNotification("No Data saved to the cloud");
            Debug.Log("No Data saved to the cloud");
            return;
        }

        var progress = BytesToString(cloudData);
        _loadedData = progress;
    }


    public void LoadFromCloud(Action<string> afterLoadAction)
    {
        if (IsAuthenticated && !_isProcessing)
        {
            StartCoroutine(LoadFromCloudRoutin(afterLoadAction));
        }
        else
        {
            Login();
        }
    }

    private IEnumerator LoadFromCloudRoutin(Action<string> loadAction)
    {
        _isProcessing = true;
        NotificationManager.Instance.SetNotification2("데이터를 불러오는 중입니다\n잠시만 기다려주세요.");
        Debug.Log("Loading game progress from the cloud.");
        
        NotificationManager.Instance.SetNotification("load1");

        ((PlayGamesPlatform) Social.Active).SavedGame.OpenWithAutomaticConflictResolution(
            m_saveFileName, //name of file.
            DataSource.ReadCacheOrNetwork,
            ConflictResolutionStrategy.UseLongestPlaytime,
            OnFileOpenToLoad);

        while (_isProcessing)
        {
            yield return null;
        }

        loadAction.Invoke(_loadedData);
    }

    public void SaveToCloud(string dataToSave)
    {
        if (IsAuthenticated)
        {
            _loadedData = dataToSave;
            _isProcessing = true;
            try
            {
                ((PlayGamesPlatform) Social.Active).SavedGame.OpenWithAutomaticConflictResolution(m_saveFileName,
                    DataSource.ReadCacheOrNetwork, ConflictResolutionStrategy.UseLongestPlaytime, OnFileOpenToSave);
            }
            catch (Exception e)
            {
                NotificationManager.Instance.SetNotification2(e.Message);
                throw;
            }
        }
        else
        {
            Login();
        }
    }

    private void OnFileOpenToSave(SavedGameRequestStatus status, ISavedGameMetadata metaData)
    {
        if (status == SavedGameRequestStatus.Success)
        {
            var data = StringToBytes(_loadedData);

            var builder = new SavedGameMetadataUpdate.Builder();

            var updatedMetadata =
                builder.WithUpdatedDescription("Saved at " + DateTime.Now).Build();

            ((PlayGamesPlatform) Social.Active).SavedGame.CommitUpdate(metaData, updatedMetadata, data, OnGameSave);

            NotificationManager.Instance.SetNotification2("클라우드 저장 완료!");
        }
        else
        {
            NotificationManager.Instance.SetNotification("Error opening Saved Game" + status);
            Debug.LogWarning("Error opening Saved Game" + status);
        }
    }


    private void OnFileOpenToLoad(SavedGameRequestStatus status, ISavedGameMetadata metaData)
    {
        if (status == SavedGameRequestStatus.Success)
        {
            ((PlayGamesPlatform) Social.Active).SavedGame.ReadBinaryData(metaData, OnGameLoad);

            LoadSuccessPanel.SetActive(true);
            LoadSuccessPanel.GetComponentInChildren<Text>().text = "데이터를 불러오는 중입니다\n잠시만 기다려주세요.";
        }
        else
        {
            NotificationManager.Instance.SetNotification("Error opening Saved Game" + status);
            Debug.LogWarning("Error opening Saved Game" + status);
        }
    }


    private void OnGameLoad(SavedGameRequestStatus status, byte[] bytes)
    {
        if (status != SavedGameRequestStatus.Success)
        {
            NotificationManager.Instance.SetNotification("Error Saving" + status);
            Debug.LogWarning("Error Saving" + status);
        }
        else
        {
            ProcessCloudData(bytes);
        }

        _isProcessing = false;
    }

    private void OnGameSave(SavedGameRequestStatus status, ISavedGameMetadata metaData)
    {
        if (status != SavedGameRequestStatus.Success)
        {
            NotificationManager.Instance.SetNotification("Error Saving" + status);
            Debug.LogWarning("Error Saving" + status);
        }

        _isProcessing = false;
    }

    private static byte[] StringToBytes(string stringToConvert)
    {
        return Encoding.UTF8.GetBytes(stringToConvert);
    }

    private static string BytesToString(byte[] bytes)
    {
        return Encoding.UTF8.GetString(bytes);
    }
}