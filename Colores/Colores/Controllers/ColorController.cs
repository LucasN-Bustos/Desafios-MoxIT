using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Colores.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Colores.Controllers
{
    public class ColorController : Controller
    {
        //Genere 3 numeros randoms y los convierto en Hexa
        public string GenColor(int valIni,int valFin)
        {
           ClaseColor color = new ClaseColor();
           Random rnd = new Random();
           int Rojo = rnd.Next(valIni, valFin); 
           int Verde = rnd.Next(valIni, valFin);
           int Azul = rnd.Next(valIni, valFin);
           color.ColorHexa = string.Concat("#", Rojo.ToString("X"), Verde.ToString("X"), Azul.ToString("X"));
           return color.ColorHexa;
        }
        //Genera una lista con las 3 dfiicultades.
        public IActionResult Index()
        {
            var lista = new List<ClaseColor>();
            lista.Add(new ClaseColor()
            {
                Id = 1,
                Dificultad = "Fácil",
                
            });
            lista.Add(new ClaseColor()
            {
                Id = 2,
                Dificultad = "Normal",
                
            });
            lista.Add(new ClaseColor()
            {
                Id = 3,
                Dificultad = "Difícil",

            });
            var list = new SelectList(lista, "Id", "Dificultad");
            ViewData["lista"]= list;
            return View();
        }
        //Segun su Id(Dificultad) genera un vector de (Colores en hexa) y lo envia al View
        public IActionResult Jugar(int Id)
        {
            ArrayList arrColor = new ArrayList();
            Random rnd = new Random();
            if(Id == 1)
            {
                for (int i = 0; i < 6; i++)
                {
                    arrColor.Add(GenColor(16,255));
                }
                    ViewData["Valid"] = arrColor[rnd.Next(0, 6)];
                    return View(arrColor);
            }
            if(Id == 2)
            {
                for (int i = 0; i < 9; i++)
                {
                    arrColor.Add(GenColor(64,220));
                }
                ViewData["Valid"] = arrColor[rnd.Next(0, 9)];
                return View(arrColor);
            }
            if(Id == 3)
            {
                for (int i = 0; i < 12; i++)
                {
                    arrColor.Add(GenColor(90,128));
                }
                ViewData["Valid"] = arrColor[rnd.Next(0, 12)];
                return View(arrColor);
            }
            return View();
        }
    }
}