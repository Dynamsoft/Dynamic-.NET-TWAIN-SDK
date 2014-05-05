<%@ Page Language="C#"%>
<%
try
{
    String DW_SaveTable = "tblImage";
    String strConnString = "Server=localhost;Database=WebTwain;Integrated Security=SSPI";
	
	String strImageName = "";
    int iFileLength = 0;
    HttpFileCollection files = HttpContext.Current.Request.Files;
    HttpPostedFile uploadfile = files["RemoteFile"];
    strImageName = uploadfile.FileName;
    iFileLength = uploadfile.ContentLength;
	String strExtraTxt = System.Web.HttpContext.Current.Request.Form["ExtraTxt"];

    Byte[] inputBuffer = new Byte[iFileLength];
    System.IO.Stream inputStream = uploadfile.InputStream;
    inputStream.Read(inputBuffer, 0, iFileLength);


    System.Data.SqlClient.SqlConnection sqlConnection = new System.Data.SqlClient.SqlConnection(strConnString);

    String SqlCmdText = "INSERT INTO " + DW_SaveTable + " (strImageName,imgImageData,strExtraTxt) VALUES (@ImageName,@Image,@ExtraTxt)";
    System.Data.SqlClient.SqlCommand sqlCmdObj = new System.Data.SqlClient.SqlCommand(SqlCmdText, sqlConnection);

    sqlCmdObj.Parameters.Add("@Image", System.Data.SqlDbType.Binary, iFileLength).Value = inputBuffer;
    sqlCmdObj.Parameters.Add("@ImageName", System.Data.SqlDbType.VarChar, 255).Value = strImageName;
	sqlCmdObj.Parameters.Add("@ExtraTxt", System.Data.SqlDbType.VarChar, 255).Value = strExtraTxt;

    sqlConnection.Open();
    sqlCmdObj.ExecuteNonQuery();
    sqlConnection.Close();
}
catch
{
} 
%>