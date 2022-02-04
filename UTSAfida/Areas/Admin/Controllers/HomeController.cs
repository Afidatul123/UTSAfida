using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UTSAfida.Data;
using UTSAfida.Models;

namespace UTSAfida.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        public  HomeController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var datajadwal = _context.Tb_Jadwal.ToList();
            return View(datajadwal);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("pelatihan, TglMulai, TglSelesai, pertemuan, Tutor, Keterangan")]
            Jadwal data)
        {
            if (ModelState.IsValid)
            {
                _context.Add(data);
                await _context.SaveChangesAsync();
                return Redirect("Index");
            }
            return View(data);
        }
    }
}
