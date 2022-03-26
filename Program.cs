using Microsoft.Data.SqlClient;
var connStr = @"server=ripper\sqlexpress;database=Test;uid=dsi;pwd=dsiadmin;TrustServerCertificate=True";
var conn = new SqlConnection(connStr);
conn.Open();
if(conn.State != System.Data.ConnectionState.Open) {
    throw new Exception("Connection failed!");
}
System.Console.WriteLine("Success!");
var sql = "Select * from test";
var cmd = new SqlCommand(sql, conn);
var reader = cmd.ExecuteReader();
while(reader.Read()) {
    var text = reader["text"].ToString();
    System.Console.WriteLine($"Text is {text}");
}
reader.Close();
conn.Close();
