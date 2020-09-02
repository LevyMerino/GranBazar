using EcommerceLM.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.EntityClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EcommerceLM.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            try
            {
                using (EcommerceContext db = new EcommerceContext())
                {
                    return View(db.Products.ToList());
                }

            }
            catch (Exception)
            {
                throw;             
            }

       
                
            
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Products p)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {
                using (var db = new EcommerceContext())
                {
                   
                    db.Products.Add(p);
                    db.SaveChanges();
                    return RedirectToAction("Index");

                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("","Error al registrar producto - " + ex.Message);
                return View();
            }    
        }
        public ActionResult Edit(int id)
        {

            try
            {
                using (var db = new EcommerceContext())
                {
                    Products select_product = db.Products.Find(id);
                    return View(select_product);
                }
            }
            catch (Exception)
            {
                throw;
            }

        }
 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Products p)
        {
            try
            {
                using (var db = new EcommerceContext())
                {
                    Products edited_product;
                    edited_product = db.Products.Find(p.ProductID);
                    edited_product.Price = p.Price;
                    edited_product.Sale = p.Sale;
                    edited_product.Category = p.Category;

                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public ActionResult Details (int id)
        {
            try
            {
                using (var db = new EcommerceContext())
                {
                    Products select_product = db.Products.Find(id);
                    return View(select_product);
                }
            }
            catch (Exception)
            {
                throw;
            }

        }
        public ActionResult Delete(int id)
        {
            try
            {
                using (var db = new EcommerceContext())
                {
                    Products select_product = db.Products.Find(id);
                    db.Products.Remove(select_product);
                    db.SaveChanges();
                    return RedirectToAction("index");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}