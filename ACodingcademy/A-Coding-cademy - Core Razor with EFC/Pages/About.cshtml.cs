﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using A_Coding_cademy___Core_Razor_with_EFC.Models.SchoolViewModels;
using A_Coding_cademy___Core_Razor_with_EFC.Models;

namespace A_Coding_cademy___Core_Razor_with_EFC.Pages
{
    public class AboutModel : PageModel
    {
        private readonly Context _context;

        public AboutModel(Context context)
        {
            _context = context;
        }

        public IList<EnrollmentDateGroup> Student { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<EnrollmentDateGroup> data =
                from student in _context.Student
                group student by student.EnrollmentDate into dateGroup
                select new EnrollmentDateGroup()
                {
                    EnrollmentDate = dateGroup.Key,
                    StudentCount = dateGroup.Count()
                };

            Student = await data.AsNoTracking().ToListAsync();
        }
    }
}