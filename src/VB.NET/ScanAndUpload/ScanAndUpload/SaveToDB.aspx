<%@ Page Language="C#"%>
<%
string strImageName = "";
try
{
    string DW_SaveTable = "tblWebTwain4";
    string DW_ConnString = "Server=localhost\\sqlexpress;Database=DemoWebTwain;User ID=sa;Password=DefeGedetf;Trusted_Connection=False";
    //string DW_ConnString = "Server=localhost;Database=DemoWebTwain;Integrated Security=SSPI";
    
    int iFileLength;
    HttpFileCollection files = HttpContext.Current.Request.Files;
    HttpPostedFile uploadfile = files["RemoteFile"];
    if (uploadfile != null)
    {
        strImageName = uploadfile.FileName;
        iFileLength = uploadfile.ContentLength;

        Byte[] inputBuffer = new Byte[iFileLength];
        System.IO.Stream inputStream;

        inputStream = uploadfile.InputStream;
        inputStream.Read(inputBuffer, 0, iFileLength);

        String strConnString;

        strConnString = DW_ConnString;

        System.Data.SqlClient.SqlConnection sqlConnection = new System.Data.SqlClient.SqlConnection(strConnString);

        String SqlCmdText = "INSERT INTO " + DW_SaveTable + " (strImageName,imgImageData) VALUES (@ImageName,@Image)";
        System.Data.SqlClient.SqlCommand sqlCmdObj = new System.Data.SqlClient.SqlCommand(SqlCmdText, sqlConnection);

        sqlCmdObj.Parameters.Add("@Image", System.Data.SqlDbType.Binary, iFileLength).Value = inputBuffer;
        sqlCmdObj.Parameters.Add("@ImageName", System.Data.SqlDbType.VarChar, 255).Value = strImageName;

        sqlConnection.Open();
        sqlCmdObj.ExecuteNonQuery();
        sqlConnection.Close();

    }
}
catch (Exception exp)
{
} 
%>