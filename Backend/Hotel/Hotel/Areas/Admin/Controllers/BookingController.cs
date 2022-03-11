using Hotel.Data;
using Hotel.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using ClosedXML.Excel;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class BookingController : Controller
    {
        private readonly AppDbContext _context;

        public BookingController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Reservation> reservations = _context.Reservations.ToList();
            string model = JsonConvert.SerializeObject(reservations);

            HttpContext.Session.SetString("e", model);
            return View(_context.Reservations.Include(a=>a.Apartment).ToList());
        }

        public IActionResult Detail(int id)
        {
            return View(_context.Reservations.Include(a => a.Apartment).FirstOrDefault(r=>r.Id == id));
        }

        public IActionResult Delete(int id)
        {
            Reservation model = _context.Reservations.Find(id);
            _context.Reservations.Remove(model);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Confirm(int id)
        {
            Reservation res = _context.Reservations.Find(id);
            res.IsActive = true;
            _context.Reservations.Update(res);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult DownloadToExcel()
        {
            string model = HttpContext.Session.GetString("e");
            List<Reservation> bookings = JsonConvert.DeserializeObject<List<Reservation>>(model);

            var wb = new XLWorkbook();
            var ws = wb.Worksheets.Add("sl1");

            ws.Row(1).Height = 5;
            ws.Row(2).Height = 30;
            ws.Row(3).Height = 18;

            ws.Column("A").Width = 0.3;
            ws.Column("B").Width = 6;
            ws.Column("C").Width = 30;
            ws.Column("D").Width = 15;

            ws.Range("B2:D2").Merge();
            ws.Range("B2:D2").Value = "Booking list";
            ws.Range("B2:D2").Style.Font.FontSize = 14;
            ws.Range("B2:D2").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            ws.Range("B2:D2").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
            ws.Range("B2:D2").Style.Font.Bold = true;

            ws.Cell("B3").Value = "#";
            ws.Cell("B3").Style.Fill.BackgroundColor = XLColor.FromArgb(0, 112, 192);
            ws.Cell("B3").Style.Font.FontColor = XLColor.White;
            ws.Cell("B3").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            ws.Cell("B3").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
            ws.Cell("B3").Style.Font.Bold = true;
            ws.Cell("B3").Style.Border.BottomBorder = XLBorderStyleValues.Thin;
            ws.Cell("B3").Style.Border.TopBorder = XLBorderStyleValues.Thin;
            ws.Cell("B3").Style.Border.LeftBorder = XLBorderStyleValues.Thin;
            ws.Cell("B3").Style.Border.RightBorder = XLBorderStyleValues.Thin;

            ws.Cell("C3").Value = "Email";
            ws.Cell("C3").Style.Fill.BackgroundColor = XLColor.FromArgb(0, 112, 192);
            ws.Cell("C3").Style.Font.FontColor = XLColor.White;
            ws.Cell("C3").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            ws.Cell("C3").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
            ws.Cell("C3").Style.Font.Bold = true;
            ws.Cell("C3").Style.Border.BottomBorder = XLBorderStyleValues.Thin;
            ws.Cell("C3").Style.Border.TopBorder = XLBorderStyleValues.Thin;
            ws.Cell("C3").Style.Border.LeftBorder = XLBorderStyleValues.Thin;
            ws.Cell("C3").Style.Border.RightBorder = XLBorderStyleValues.Thin;

            ws.Cell("D3").Value = "Order Date";
            ws.Cell("D3").Style.Fill.BackgroundColor = XLColor.FromArgb(0, 112, 192);
            ws.Cell("D3").Style.Font.FontColor = XLColor.White;
            ws.Cell("D3").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            ws.Cell("D3").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
            ws.Cell("D3").Style.Font.Bold = true;
            ws.Cell("D3").Style.Border.BottomBorder = XLBorderStyleValues.Thin;
            ws.Cell("D3").Style.Border.TopBorder = XLBorderStyleValues.Thin;
            ws.Cell("D3").Style.Border.LeftBorder = XLBorderStyleValues.Thin;
            ws.Cell("D3").Style.Border.RightBorder = XLBorderStyleValues.Thin;

            ws.Cell("E3").Value = "Start Date";
            ws.Cell("E3").Style.Fill.BackgroundColor = XLColor.FromArgb(0, 112, 192);
            ws.Cell("E3").Style.Font.FontColor = XLColor.White;
            ws.Cell("E3").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            ws.Cell("E3").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
            ws.Cell("E3").Style.Font.Bold = true;
            ws.Cell("E3").Style.Border.BottomBorder = XLBorderStyleValues.Thin;
            ws.Cell("E3").Style.Border.TopBorder = XLBorderStyleValues.Thin;
            ws.Cell("E3").Style.Border.LeftBorder = XLBorderStyleValues.Thin;
            ws.Cell("E3").Style.Border.RightBorder = XLBorderStyleValues.Thin;

            ws.Cell("F3").Value = "End Date";
            ws.Cell("F3").Style.Fill.BackgroundColor = XLColor.FromArgb(0, 112, 192);
            ws.Cell("F3").Style.Font.FontColor = XLColor.White;
            ws.Cell("F3").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            ws.Cell("F3").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
            ws.Cell("F3").Style.Font.Bold = true;
            ws.Cell("F3").Style.Border.BottomBorder = XLBorderStyleValues.Thin;
            ws.Cell("F3").Style.Border.TopBorder = XLBorderStyleValues.Thin;
            ws.Cell("F3").Style.Border.LeftBorder = XLBorderStyleValues.Thin;
            ws.Cell("F3").Style.Border.RightBorder = XLBorderStyleValues.Thin;

            ws.Cell("G3").Value = "Name";
            ws.Cell("G3").Style.Fill.BackgroundColor = XLColor.FromArgb(0, 112, 192);
            ws.Cell("G3").Style.Font.FontColor = XLColor.White;
            ws.Cell("G3").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            ws.Cell("G3").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
            ws.Cell("G3").Style.Font.Bold = true;
            ws.Cell("G3").Style.Border.BottomBorder = XLBorderStyleValues.Thin;
            ws.Cell("G3").Style.Border.TopBorder = XLBorderStyleValues.Thin;
            ws.Cell("G3").Style.Border.LeftBorder = XLBorderStyleValues.Thin;
            ws.Cell("G3").Style.Border.RightBorder = XLBorderStyleValues.Thin;

            ws.Cell("H3").Value = "Surname";
            ws.Cell("H3").Style.Fill.BackgroundColor = XLColor.FromArgb(0, 112, 192);
            ws.Cell("H3").Style.Font.FontColor = XLColor.White;
            ws.Cell("H3").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            ws.Cell("H3").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
            ws.Cell("H3").Style.Font.Bold = true;
            ws.Cell("H3").Style.Border.BottomBorder = XLBorderStyleValues.Thin;
            ws.Cell("H3").Style.Border.TopBorder = XLBorderStyleValues.Thin;
            ws.Cell("H3").Style.Border.LeftBorder = XLBorderStyleValues.Thin;
            ws.Cell("H3").Style.Border.RightBorder = XLBorderStyleValues.Thin;

            ws.Cell("I3").Value = "Phone";
            ws.Cell("I3").Style.Fill.BackgroundColor = XLColor.FromArgb(0, 112, 192);
            ws.Cell("I3").Style.Font.FontColor = XLColor.White;
            ws.Cell("I3").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            ws.Cell("I3").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
            ws.Cell("I3").Style.Font.Bold = true;
            ws.Cell("I3").Style.Border.BottomBorder = XLBorderStyleValues.Thin;
            ws.Cell("I3").Style.Border.TopBorder = XLBorderStyleValues.Thin;
            ws.Cell("I3").Style.Border.LeftBorder = XLBorderStyleValues.Thin;
            ws.Cell("I3").Style.Border.RightBorder = XLBorderStyleValues.Thin;

            ws.Cell("J3").Value = "Country";
            ws.Cell("J3").Style.Fill.BackgroundColor = XLColor.FromArgb(0, 112, 192);
            ws.Cell("J3").Style.Font.FontColor = XLColor.White;
            ws.Cell("J3").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            ws.Cell("J3").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
            ws.Cell("J3").Style.Font.Bold = true;
            ws.Cell("J3").Style.Border.BottomBorder = XLBorderStyleValues.Thin;
            ws.Cell("J3").Style.Border.TopBorder = XLBorderStyleValues.Thin;
            ws.Cell("J3").Style.Border.LeftBorder = XLBorderStyleValues.Thin;
            ws.Cell("J3").Style.Border.RightBorder = XLBorderStyleValues.Thin;

            ws.Cell("K3").Value = "Amount";
            ws.Cell("K3").Style.Fill.BackgroundColor = XLColor.FromArgb(0, 112, 192);
            ws.Cell("K3").Style.Font.FontColor = XLColor.White;
            ws.Cell("K3").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            ws.Cell("K3").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
            ws.Cell("K3").Style.Font.Bold = true;
            ws.Cell("K3").Style.Border.BottomBorder = XLBorderStyleValues.Thin;
            ws.Cell("K3").Style.Border.TopBorder = XLBorderStyleValues.Thin;
            ws.Cell("K3").Style.Border.LeftBorder = XLBorderStyleValues.Thin;
            ws.Cell("K3").Style.Border.RightBorder = XLBorderStyleValues.Thin;

            ws.Cell("L3").Value = "Tax";
            ws.Cell("L3").Style.Fill.BackgroundColor = XLColor.FromArgb(0, 112, 192);
            ws.Cell("L3").Style.Font.FontColor = XLColor.White;
            ws.Cell("L3").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            ws.Cell("L3").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
            ws.Cell("L3").Style.Font.Bold = true;
            ws.Cell("L3").Style.Border.BottomBorder = XLBorderStyleValues.Thin;
            ws.Cell("L3").Style.Border.TopBorder = XLBorderStyleValues.Thin;
            ws.Cell("L3").Style.Border.LeftBorder = XLBorderStyleValues.Thin;
            ws.Cell("L3").Style.Border.RightBorder = XLBorderStyleValues.Thin;

            ws.Cell("M3").Value = "Total Amount";
            ws.Cell("M3").Style.Fill.BackgroundColor = XLColor.FromArgb(0, 112, 192);
            ws.Cell("M3").Style.Font.FontColor = XLColor.White;
            ws.Cell("M3").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            ws.Cell("M3").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
            ws.Cell("M3").Style.Font.Bold = true;
            ws.Cell("M3").Style.Border.BottomBorder = XLBorderStyleValues.Thin;
            ws.Cell("M3").Style.Border.TopBorder = XLBorderStyleValues.Thin;
            ws.Cell("M3").Style.Border.LeftBorder = XLBorderStyleValues.Thin;
            ws.Cell("M3").Style.Border.RightBorder = XLBorderStyleValues.Thin;

            ws.Cell("N3").Value = "Apartment Id";
            ws.Cell("N3").Style.Fill.BackgroundColor = XLColor.FromArgb(0, 112, 192);
            ws.Cell("N3").Style.Font.FontColor = XLColor.White;
            ws.Cell("N3").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            ws.Cell("N3").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
            ws.Cell("N3").Style.Font.Bold = true;
            ws.Cell("N3").Style.Border.BottomBorder = XLBorderStyleValues.Thin;
            ws.Cell("N3").Style.Border.TopBorder = XLBorderStyleValues.Thin;
            ws.Cell("N3").Style.Border.LeftBorder = XLBorderStyleValues.Thin;
            ws.Cell("N3").Style.Border.RightBorder = XLBorderStyleValues.Thin;
            for (int i = 0; i < bookings.Count; i++)
            {
                ws.Cell("B" + (i + 4)).Value = i + 1;
                ws.Cell("B" + (i + 4)).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                ws.Cell("B" + (i + 4)).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                ws.Cell("B" + (i + 4)).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                ws.Cell("B" + (i + 4)).Style.Border.TopBorder = XLBorderStyleValues.Thin;
                ws.Cell("B" + (i + 4)).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                ws.Cell("B" + (i + 4)).Style.Border.RightBorder = XLBorderStyleValues.Thin;

                ws.Cell("C" + (i + 4)).Value = bookings[i].Email;
                ws.Cell("C" + (i + 4)).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                ws.Cell("C" + (i + 4)).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                ws.Cell("C" + (i + 4)).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                ws.Cell("C" + (i + 4)).Style.Border.TopBorder = XLBorderStyleValues.Thin;
                ws.Cell("C" + (i + 4)).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                ws.Cell("C" + (i + 4)).Style.Border.RightBorder = XLBorderStyleValues.Thin;

                ws.Cell("D" + (i + 4)).Value = bookings[i].CreatedDate.ToString("dd.MM.yyyy");
                ws.Cell("D" + (i + 4)).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                ws.Cell("D" + (i + 4)).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                ws.Cell("D" + (i + 4)).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                ws.Cell("D" + (i + 4)).Style.Border.TopBorder = XLBorderStyleValues.Thin;
                ws.Cell("D" + (i + 4)).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                ws.Cell("D" + (i + 4)).Style.Border.RightBorder = XLBorderStyleValues.Thin;

                ws.Cell("E" + (i + 4)).Value = bookings[i].StartDate.ToString("dd.MM.yyyy");
                ws.Cell("E" + (i + 4)).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                ws.Cell("E" + (i + 4)).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                ws.Cell("E" + (i + 4)).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                ws.Cell("E" + (i + 4)).Style.Border.TopBorder = XLBorderStyleValues.Thin;
                ws.Cell("E" + (i + 4)).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                ws.Cell("E" + (i + 4)).Style.Border.RightBorder = XLBorderStyleValues.Thin;

                ws.Cell("F" + (i + 4)).Value = bookings[i].EndDate.ToString("dd.MM.yyyy");
                ws.Cell("F" + (i + 4)).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                ws.Cell("F" + (i + 4)).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                ws.Cell("F" + (i + 4)).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                ws.Cell("F" + (i + 4)).Style.Border.TopBorder = XLBorderStyleValues.Thin;
                ws.Cell("F" + (i + 4)).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                ws.Cell("F" + (i + 4)).Style.Border.RightBorder = XLBorderStyleValues.Thin;

                ws.Cell("G" + (i + 4)).Value = bookings[i].Name;
                ws.Cell("G" + (i + 4)).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                ws.Cell("G" + (i + 4)).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                ws.Cell("G" + (i + 4)).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                ws.Cell("G" + (i + 4)).Style.Border.TopBorder = XLBorderStyleValues.Thin;
                ws.Cell("G" + (i + 4)).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                ws.Cell("G" + (i + 4)).Style.Border.RightBorder = XLBorderStyleValues.Thin;

                ws.Cell("H" + (i + 4)).Value = bookings[i].Surname;
                ws.Cell("H" + (i + 4)).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                ws.Cell("H" + (i + 4)).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                ws.Cell("H" + (i + 4)).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                ws.Cell("H" + (i + 4)).Style.Border.TopBorder = XLBorderStyleValues.Thin;
                ws.Cell("H" + (i + 4)).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                ws.Cell("H" + (i + 4)).Style.Border.RightBorder = XLBorderStyleValues.Thin;

                ws.Cell("I" + (i + 4)).Value = bookings[i].Phone;
                ws.Cell("I" + (i + 4)).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                ws.Cell("I" + (i + 4)).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                ws.Cell("I" + (i + 4)).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                ws.Cell("I" + (i + 4)).Style.Border.TopBorder = XLBorderStyleValues.Thin;
                ws.Cell("I" + (i + 4)).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                ws.Cell("I" + (i + 4)).Style.Border.RightBorder = XLBorderStyleValues.Thin;

                ws.Cell("J" + (i + 4)).Value = bookings[i].Country;
                ws.Cell("J" + (i + 4)).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                ws.Cell("J" + (i + 4)).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                ws.Cell("J" + (i + 4)).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                ws.Cell("J" + (i + 4)).Style.Border.TopBorder = XLBorderStyleValues.Thin;
                ws.Cell("J" + (i + 4)).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                ws.Cell("J" + (i + 4)).Style.Border.RightBorder = XLBorderStyleValues.Thin;

                ws.Cell("K" + (i + 4)).Value = bookings[i].Amount;
                ws.Cell("K" + (i + 4)).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                ws.Cell("K" + (i + 4)).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                ws.Cell("K" + (i + 4)).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                ws.Cell("K" + (i + 4)).Style.Border.TopBorder = XLBorderStyleValues.Thin;
                ws.Cell("K" + (i + 4)).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                ws.Cell("K" + (i + 4)).Style.Border.RightBorder = XLBorderStyleValues.Thin;

                ws.Cell("L" + (i + 4)).Value = bookings[i].Tax;
                ws.Cell("L" + (i + 4)).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                ws.Cell("L" + (i + 4)).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                ws.Cell("L" + (i + 4)).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                ws.Cell("L" + (i + 4)).Style.Border.TopBorder = XLBorderStyleValues.Thin;
                ws.Cell("L" + (i + 4)).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                ws.Cell("L" + (i + 4)).Style.Border.RightBorder = XLBorderStyleValues.Thin;

                ws.Cell("M" + (i + 4)).Value = bookings[i].TotalAmount;
                ws.Cell("M" + (i + 4)).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                ws.Cell("M" + (i + 4)).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                ws.Cell("M" + (i + 4)).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                ws.Cell("M" + (i + 4)).Style.Border.TopBorder = XLBorderStyleValues.Thin;
                ws.Cell("M" + (i + 4)).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                ws.Cell("M" + (i + 4)).Style.Border.RightBorder = XLBorderStyleValues.Thin;

                ws.Cell("N" + (i + 4)).Value = bookings[i].ApartmentId;
                ws.Cell("N" + (i + 4)).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                ws.Cell("N" + (i + 4)).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                ws.Cell("N" + (i + 4)).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                ws.Cell("N" + (i + 4)).Style.Border.TopBorder = XLBorderStyleValues.Thin;
                ws.Cell("N" + (i + 4)).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                ws.Cell("N" + (i + 4)).Style.Border.RightBorder = XLBorderStyleValues.Thin;
            }

            using (var stream = new MemoryStream())
            {
                wb.SaveAs(stream);
                var content = stream.ToArray();

                return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Reservation.xlsx");
            }
        }
    }
}
