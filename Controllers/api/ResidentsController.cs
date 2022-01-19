using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Village_MVC.Models;

namespace Village_MVC.Controllers.api
{
    public class ResidentsController : ApiController
    {
        VilageContext DBC = new VilageContext();
        // GET: api/Residents
        public IHttpActionResult Get()
        {
           
            try
            {
                List<Resident> AllResidents = DBC.Resident.ToList();

                return Ok(new { AllResidents });
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }

        // GET: api/Residents/5
        public async Task<IHttpActionResult>  Get(int id)
        {
            try
            {
                Resident OneResident = await DBC.Resident.FindAsync(id);

                return Ok(new { OneResident });
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/Residents
        public async Task<IHttpActionResult> Post([FromBody] Resident resident)
        {
            try
            {
                DBC.Resident.Add(resident);
                await DBC.SaveChangesAsync();
                return Ok("added");
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/Residents/5
        public async Task<IHttpActionResult> Put(int id, [FromBody] Resident resident)
        {
            try
            {
                Resident UpDateResident = await DBC.Resident.FindAsync(id);
                UpDateResident.firstName = resident.firstName;
                UpDateResident.lastName = resident.lastName;
                UpDateResident.fatherName = resident.fatherName;
                UpDateResident.Gender = resident.Gender;
                UpDateResident.bornInVillage = resident.bornInVillage;
                UpDateResident.yearOfBirth = resident.yearOfBirth;

                await DBC.SaveChangesAsync();
                return Ok("Eddit");
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Residents/5
        public async Task<IHttpActionResult> Delete(int id)
        {
            try
            {
                Resident FindAndRmoveResident = await DBC.Resident.FindAsync(id);
                DBC.Resident.Remove(FindAndRmoveResident);
                await DBC.SaveChangesAsync();
                return Ok("Removed");
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
