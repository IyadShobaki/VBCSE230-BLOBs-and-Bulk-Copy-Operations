Imports System.Data.SqlClient
Imports System.IO

Public Class Form1
    Private NorthWindConnection As New SqlConnection(My.Settings.DB1ConnectionString)
    Private CompleteFilePath As String = ""
    Private SavePath As String = ""

    Private Sub CreateDocumentStorageTableToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CreateDocumentStorageTableToolStripMenuItem.Click
        Dim response As DialogResult =
            MessageBox.Show("Create the Document Storage Table?" &
                            "Click Yes to create a new DocumentStorage Table. " &
                            "Click No to cancel",
                            "Create DocumentStorage Table", MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question)
        Select Case response
            Case Is = Windows.Forms.DialogResult.Yes
                CreateDocumentStorageTable()
                MessageBox.Show("Table created successfully!")
            Case Is = Windows.Forms.DialogResult.No
                RefreshBlobList()
        End Select

    End Sub
    Private Sub CreateDocumentStorageTable()
        Dim CreateTableCommand As New SqlCommand
        CreateTableCommand.Connection = NorthWindConnection
        CreateTableCommand.CommandType = CommandType.Text
        CreateTableCommand.CommandText =
            "IF OBJECT_ID ('DocumentStorage' ) is not null " &
            "Drop table DocumentStorage; " &
            "create table DocumentStorage(" &
            "DocumentID int identity(1,1) not null, " &
            "FileName nvarchar(255) not null, " &
            "DocumentFile varbinary(max) not null)"

        CreateTableCommand.Connection.Open()
        CreateTableCommand.ExecuteNonQuery()
        CreateTableCommand.Connection.Close()

    End Sub
    Private Sub RefreshBlobList()
        Dim GetBLOBListCommand As New SqlCommand(
            "Select FileName from DocumentStorage", NorthWindConnection)
        Dim reader As SqlDataReader
        GetBLOBListCommand.Connection.Open()
        reader = GetBLOBListCommand.ExecuteReader
        BLOBList.Items.Clear()
        While reader.Read
            BLOBList.Items.Add(reader(0))
        End While


        reader.Close()
        GetBLOBListCommand.Connection.Close()
        BLOBList.SelectedIndex = 0

    End Sub
    Private Sub GetCompleteFilePath()
        Dim OpenDialog As New OpenFileDialog
        OpenDialog.Title = "Select Document File to Save"
        OpenDialog.ShowDialog()
        CompleteFilePath = OpenDialog.FileName
    End Sub
    Private Sub GetSavePath()
        Dim SavePathDialog As New FolderBrowserDialog
        SavePathDialog.Description = "Select a folder to restore BLOB file to"
        SavePathDialog.ShowDialog()
        SavePath = SavePathDialog.SelectedPath
    End Sub
    Private Sub SaveBLOBToDatabase()
        GetCompleteFilePath()
        Dim BLOB() As Byte
        Dim FileStream As New IO.FileStream(CompleteFilePath, IO.FileMode.Open, IO.FileAccess.Read)
        Dim reader As New IO.BinaryReader(FileStream)

        BLOB = reader.ReadBytes(CInt(My.Computer.FileSystem.GetFileInfo(CompleteFilePath).Length))
        FileStream.Close()
        reader.Close()

        Dim SaveDocCommand As New SqlCommand
        SaveDocCommand.Connection = NorthWindConnection
        SaveDocCommand.CommandText = "insert into DocumentStorage" &
            "(FileName, DocumentFile)" &
            "values (@FileName, @DocumentFile)"
        Dim FileNameParameter As New SqlParameter("@FileName", SqlDbType.NChar)
        Dim DocumentFileParameter As New SqlParameter("@DocumentFile", SqlDbType.Binary)
        SaveDocCommand.Parameters.Add(FileNameParameter)
        SaveDocCommand.Parameters.Add(DocumentFileParameter)

        FileNameParameter.Value =
            CompleteFilePath.Substring(CompleteFilePath.LastIndexOf("\") + 1)
        DocumentFileParameter.Value = BLOB
        Try
            SaveDocCommand.Connection.Open()
            SaveDocCommand.ExecuteNonQuery()
            MessageBox.Show(FileNameParameter.Value.ToString &
                            " Saved to database.", "BLOB Saved!", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Saved Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally

            SaveDocCommand.Connection.Close()

        End Try


    End Sub
    Private Sub FetchBlobFromDatabsae()
        If BLOBList.Text = "" Then
            MessageBox.Show("select a BLOB to fetch from the ComboBox")
            Exit Sub
        End If
        GetSavePath()
        Dim GetBlobCommand As New SqlCommand(
            "select FileName, DocumentFile " &
            "from DocumentStorage " &
            "where FileName = @DocName", NorthWindConnection)
        GetBlobCommand.Parameters.Add("@DocName", SqlDbType.NVarChar).Value = BLOBList.Text

        Dim CurrentIndex As Long = 0
        Dim BufferSize As Integer = 100
        Dim BytesReturned As Long
        Dim Blob(BufferSize - 1) As Byte
        GetBlobCommand.Connection.Open()
        Dim reader As SqlDataReader =
            GetBlobCommand.ExecuteReader(CommandBehavior.SequentialAccess)
        Do While reader.Read
            Dim FileStream As New IO.FileStream(SavePath & "\" & reader("FileName").ToString, IO.FileMode.OpenOrCreate, IO.FileAccess.Write)
            Dim writer As New IO.BinaryWriter(FileStream)
            CurrentIndex = 0
            BytesReturned = reader.GetBytes(1, CurrentIndex, Blob, 0, BufferSize)

            Do While BytesReturned = BufferSize
                writer.Write(Blob)
                writer.Flush()
                CurrentIndex += BufferSize
                BytesReturned = reader.GetBytes(1, CurrentIndex, Blob, 0, BufferSize)
            Loop
            writer.Write(Blob, 0, CInt(BytesReturned - 1))
            writer.Flush()
            writer.Close()
            FileStream.Close()

        Loop
        reader.Close()
        GetBlobCommand.Connection.Close()

    End Sub

    Private Sub SaveBLOBToDatabseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveBLOBToDatabseToolStripMenuItem.Click
        SaveBLOBToDatabase()

        RefreshBlobList()
    End Sub

    Private Sub FetchBLOBFromDatabaseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FetchBLOBFromDatabaseToolStripMenuItem.Click
        FetchBlobFromDatabsae()

    End Sub

    Private Sub BLOBList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles BLOBList.SelectedIndexChanged
        Dim command As New SqlCommand("select FileName, DocumentFile from DocumentStorage where FileName = @FileName", NorthWindConnection)
        command.Parameters.Add("@FileName", SqlDbType.NVarChar).Value = BLOBList.Text
        Dim adapter As New SqlDataAdapter(command)
        Dim table As New DataTable()
        adapter.Fill(table)
        Dim img() As Byte
        img = table(0)(1)
        Dim ms As New MemoryStream(img)
        PictureBox1.Image = Image.FromStream(ms)

    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Application.Exit()
    End Sub
End Class
