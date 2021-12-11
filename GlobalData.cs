using MySql.Data.MySqlClient;
using UnityEngine;

[System.Serializable]
public class ConnectionInfo
{
    public string serverIP = "";
    public string mysqlUserID = "";
    public string pwd = "";
    public string databaseName = "";
}

public class GlobalData : MonoBehaviour
{
    public PlayerPrefsData<ConnectionInfo> connectionInfo;

    private void Start()
    {
        connectionInfo = new PlayerPrefsData<ConnectionInfo>("ConnectionInfo");
        var data = connectionInfo.data;
        string connectStr = $"Server={data.serverIP};Database={data.databaseName};Uid={data.mysqlUserID};Pwd={data.pwd};Charset=utf8";
        using (MySqlConnection connection = new MySqlConnection(connectStr))
        //using으로 하면 아래 스코프에서만 해당 connection이 실행되고 영역을 벗어나면 바로 자원해제 된다
        {
            connection.Open();

            string sql = "SELECT * FROM game_db.leveldata;";
            MySqlCommand cmd = new MySqlCommand(sql, connection);
            MySqlDataReader rdr = cmd.ExecuteReader(); //rdr 오픈하는 거랑 같은 의미
            while (rdr.Read())
            {
                Debug.LogFormat($"{rdr["level"]}: {rdr["maxexp"]}");
            }
            rdr.Close();
        }
    }

    private void OnDestroy()
    {
        connectionInfo.SaveData();
    }
}

