using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace library2 
{
  [ApiController]
  [Route("api/[controller]")]
  public class LibraryController : ControllerBase
  {
   [HttpGet]
   public ActionResult<IEnumerable<Library>> GetAll()
   {
     try
     {
        return Ok(FakeDB.Librarys);
     }
     catch (Exception err)
     {
         return BadRequest(err.Message);
     }
   }

   [HttpPost]
   public ActionResult<Library> Create([FromBody] Library newLibrary)
   {
     try
     {
         FakeDB.Librarys.Add(newLibrary);
         return Created($"api/librarys/{newLibrary.Id}",newLibrary);
     }
     catch (Exception err)
     {
         return BadRequest(err.Message);
     }
   }

   [HttpGet("{libraryId}")]
   public ActionResult<Library> GetOne(string libraryId)
   {
     try
     {
        Library foundLibrary = FakeDB.Librarys.Find(library => library.Id == libraryId);
        if(foundLibrary == null)
        {
          throw new Exception("bad id");
        }
        return Ok(foundLibrary);
     }
     catch (Exception err)
     {
         return BadRequest(err.Message);
     }
   }


   [HttpDelete("{id}")]
   public ActionResult<string> Delete(string id)
   {
     try
     {
         Library libraryToDelete = FakeDB.Librarys.Find(l => l.Id == id);
         if(libraryToDelete == null)
         {
           throw new Exception("bad id");
         }
         FakeDB.Librarys.Remove(libraryToDelete);
         return Ok("Deleted");
     }
     catch (System.Exception)
     {
         
         throw;
     }
   }

   [HttpPut("{id}")]
   public ActionResult<Library> Edit(string id, [FromBody]Library updatedLibrary)
   {
     try
     {
         Library libraryToUpdate = FakeDB.Librarys.Find(l => l.Id == id);
         if(libraryToUpdate == null)
         {
           throw new Exception ("bad id");
         }
         libraryToUpdate.Title = updatedLibrary.Title == null ? libraryToUpdate.Title : updatedLibrary.Title;
         libraryToUpdate.Description = updatedLibrary.Description == null ? libraryToUpdate.Description : updatedLibrary.Description;
         libraryToUpdate.Price = updatedLibrary.Price;
        return Ok(libraryToUpdate);
     }
     catch (System.Exception err)
     {
         return BadRequest(err.Message);
     }
   }
  }
}
