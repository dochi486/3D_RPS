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
        //using���� �ϸ� �Ʒ� ������������ �ش� connection�� ����ǰ� ������ ����� �ٷ� �ڿ����� �ȴ�
        {
            connection.Open();

            string sql = "SELECT * FROM game_db.leveldata;";
            MySqlCommand cmd = new MySqlCommand(sql, connection);
            MySqlDataReader rdr = cmd.ExecuteReader(); //rdr �����ϴ� �Ŷ� ���� �ǹ�
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

