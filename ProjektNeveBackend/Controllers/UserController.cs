using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjektNeveBackend.Models;

namespace ProjektNeveBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet("uId")]

        public IActionResult Get(string uId)
        {
            uId = "a95c9c2a-18e6-4eac-b547-3b217958c84a";
            if (Program.LoggedInUsers.ContainsKey(uId) && Program.LoggedInUsers[uId].Jogosultsag == 9)
            {
                using (var cx = new BackendAlapContext())
                {
                    try
                    {
                        return Ok(cx.Users.Include(f => f.JogosultsagNavigation).ToList());
                    }
                    catch (Exception ex)
                    {
                        return BadRequest(ex.Message);
                    }
                }
            }
            else
            {
                return BadRequest("Nincs joga a művelethez!");
            }
        }

        [HttpGet("uId,felhasznaloNev")]

        public IActionResult GetNev(string uId, string felhasznaloNev)
        {
            uId = "a95c9c2a-18e6-4eac-b547-3b217958c84a";
            if (Program.LoggedInUsers.ContainsKey(uId) && Program.LoggedInUsers[uId].Jogosultsag > 6)
            {
                using (var cx = new BackendAlapContext())
                {
                    try
                    {
                        return Ok(cx.Users.FirstOrDefault(f => f.FelhasznaloNev == felhasznaloNev));
                    }
                    catch (Exception ex)
                    {
                        return BadRequest(ex.Message);
                    }
                }
            }
            else
            {
                return BadRequest("Nincs joga a művelethez!");
            }
        }

        [HttpPost("{uId}")]

        public async Task<IActionResult> Post(string uId, User user)
        {
            uId = "a95c9c2a-18e6-4eac-b547-3b217958c84a";
            if (Program.LoggedInUsers.ContainsKey(uId) && Program.LoggedInUsers[uId].Jogosultsag == 9)
            {
                using (var cx = new BackendAlapContext())
                {
                    try
                    {
                        cx.Add(user);
                        await cx.SaveChangesAsync();
                        return Ok("Sikeres felhasználó hozzáadás");
                    }
                    catch (Exception ex)
                    {
                        return BadRequest(ex.Message);
                    }
                }
            }
            else
            {
                return BadRequest("Nincs joga a művelethez!");
            }
        }

        [HttpPut("{uId}")]

        public async Task<IActionResult> Put(string uId, User user)
        {
            uId = "a95c9c2a-18e6-4eac-b547-3b217958c84a";
            if (Program.LoggedInUsers.ContainsKey(uId) && Program.LoggedInUsers[uId].Jogosultsag == 9)
            {
                using (var cx = new BackendAlapContext())
                {
                    try
                    {
                        cx.Update(user);
                        await cx.SaveChangesAsync();
                        return Ok("Sikeres felhasználó módosítás");
                    }
                    catch (Exception ex)
                    {
                        return BadRequest(ex.Message);
                    }
                }
            }
            else
            {
                return BadRequest("Nincs joga a művelethez!");
            }

        }

        [HttpDelete("{uId}")]

        public async Task<IActionResult> Delete(string uId, int id)
        {
            uId = "a95c9c2a-18e6-4eac-b547-3b217958c84a";
            if (Program.LoggedInUsers.ContainsKey(uId) && Program.LoggedInUsers[uId].Jogosultsag == 9)
            {
                using (var cx = new BackendAlapContext())
                {
                    try
                    {
                        User user=new User { Id = id };
                        cx.Remove(user);
                        await cx.SaveChangesAsync();
                        return Ok("Sikeres felhasználó törlés.");
                    }
                    catch (Exception ex)
                    {
                        return BadRequest(ex.Message);
                    }
                }
            }
            else
            {
                return BadRequest("Nincs joga a művelethez!");
            }

        }

    }
}
