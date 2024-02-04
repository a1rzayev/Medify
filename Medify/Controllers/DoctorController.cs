using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Medify.Models;
using Medify.Resources;

namespace Medify.Controllers;

public class DoctorController : Controller
{
   private readonly MedRepository medRepository = new MedRepository();
        [HttpGet]
        public IActionResult GetDoctors(){
            var doctors = medRepository.GetDoctors();
            if(doctors is null){
                return NotFound("Nothing Found");
            }
            return View(doctors);
        }
        [HttpGet]
        public IActionResult GetDoctorById(int id){
            var doctor = medRepository.GetDoctorById(id);
            if(doctor is null){
                return NotFound($"Game({id}) not found");
            }
            return View(doctor);
        }
        [HttpGet]
        public IActionResult GetDoctorByName(string name){
            var doctor = medRepository.GetDoctorByName(name);
            if(doctor is null){
                return NotFound($"({name}) not found");
            }
            return View(doctor);
        }
        [HttpPost]
        public IActionResult AddDoctor(Doctor doctor){
            var count = medRepository.AddDoctor(doctor);
            if(count == 0)
                return StatusCode(505);
            return Ok();
        }
        [HttpDelete]
        public IActionResult DeleteDoctor(int id){
            var count = medRepository.DeleteDoctor(id);
            if(count==0)
                return NotFound();
            return Ok();
        }
}
