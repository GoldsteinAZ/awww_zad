using Microsoft.AspNetCore.Mvc;
using awww_az.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace awww_az.Controllers
{
    public class StudentController : Controller
    {
        // Lista predefiniowanych studentów
        private static List<Student> _students = new List<Student>
        {
            new Student {
                Id = 1,
                FirstName = "Jan",
                LastName = "Kowalski",
                IndexNumber = "s12345",
                DateOfBirth = new DateTime(1998, 5, 10),
                FieldOfStudy = "Informatyka"
            },
            new Student {
                Id = 2,
                FirstName = "Anna",
                LastName = "Nowak",
                IndexNumber = "s23456",
                DateOfBirth = new DateTime(1999, 8, 15),
                FieldOfStudy = "Matematyka"
            },
            new Student {
                Id = 3,
                FirstName = "Piotr",
                LastName = "Wiśniewski",
                IndexNumber = "s34567",
                DateOfBirth = new DateTime(1997, 3, 20),
                FieldOfStudy = "Fizyka"
            }
        };

        // Akcja wyświetlająca listę studentów
        public IActionResult Index()
        {
            return View(_students);
        }

        // Akcja wyświetlająca szczegóły wybranego studenta
        public IActionResult Details(int id)
        {
            var student = _students.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }
    }
}
