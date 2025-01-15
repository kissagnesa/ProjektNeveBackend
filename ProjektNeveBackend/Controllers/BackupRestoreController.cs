using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using ProjektNeveBackend.Models;

namespace ProjektNeveBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BackupRestoreController : ControllerBase
    {
        private readonly IWebHostEnvironment _env;

        public BackupRestoreController(IWebHostEnvironment env)
        {
            _env = env;
        }

        [Route("Backup/{uId},{fileName}")]
        [HttpGet]
        public async Task<ActionResult> SQLBackup(string uId, string fileName)
        {

            //if (Program.LoggedInUsers.ContainsKey(uId) && Program.LoggedInUsers[uId].Jogosultsag == 9)
            if (true)
            {
                string hibaUzenet = "";
                using (var context = new BackendAlapContext())
                {
                    string sqlDataSource = context.Database.GetConnectionString()!;
                    MySqlCommand command = new MySqlCommand();
                    MySqlBackup backup = new MySqlBackup(command);
                    using (MySqlConnection myConnection = new MySqlConnection(sqlDataSource))
                    {
                        try
                        {
                            command.Connection = myConnection;
                            myConnection.Open();
                            var filePath = "SQLBackupRestore/" + fileName;
                            backup.ExportToFile(filePath);
                            myConnection.Close();
                            if (System.IO.File.Exists(filePath))
                            {
                                var bytes = await System.IO.File.ReadAllBytesAsync(filePath);
                                return File(bytes, "text/plain", Path.GetFileName(filePath));
                            }
                            else
                            {
                                hibaUzenet = "Nincs ilyen file!";
                                byte[] a = new byte[hibaUzenet.Length];
                                for (int i = 0; i < hibaUzenet.Length; i++)
                                {
                                    a[i] = Convert.ToByte(hibaUzenet[i]);
                                }
                                return File(a, "text/plain", "Error.txt");
                            }

                        }
                        catch (Exception ex)
                        {
                            return new JsonResult(ex.Message);
                        }
                    }
                }
            }
            else
            {
                return BadRequest("Nincs bejelentkezve/jogosultsága!");
            }
        }

        [Route("Restore/{uId}")]
        [HttpPost]

        public JsonResult SQLRestore(string uId)
        {
            //if (Program.LoggedInUsers.ContainsKey(uId) && Program.LoggedInUsers[uId].Jogosultsag == 9)
            if (true)
            {
                try
                {
                    var contex = new BackendAlapContext();
                    string sqlDataSource = contex.Database.GetConnectionString()!;
                    var httpRequest = Request.Form;
                    var postedFile = httpRequest.Files[0];
                    string fileName = postedFile.FileName;
                    var filePath = _env.ContentRootPath + "/SQLBackupRestore" + fileName;
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        postedFile.CopyTo(stream);
                    }

                    MySqlCommand command = new MySqlCommand();
                    MySqlBackup restore = new MySqlBackup(command);
                    using (MySqlConnection mySqlConnection = new MySqlConnection(sqlDataSource))
                    {
                        try
                        {
                            command.Connection = mySqlConnection;
                            mySqlConnection.Open();
                            restore.ImportFromFile(filePath);
                            System.IO.File.Delete(filePath);
                            return new JsonResult("A visszaállítás sikeresen lefutott.");
                        }
                        catch
                        {
                            return new JsonResult("Mentésfájl sikeresen feltöltve. Az sql szerver nem érhető el!");
                        }
                    }
                }
                catch (Exception)
                {
                    return new JsonResult("Nincs kiválasztva mentés fájl!");
                }
            }

            else
            {
                return new JsonResult("Nincs bejelentkezve/jogosultsága!");
            }
        }

    }
}
