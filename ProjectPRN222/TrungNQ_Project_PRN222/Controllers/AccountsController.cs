﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TrungNQ_Project_PRN222.DAL;
using TrungNQ_Project_PRN222.Filter;
using TrungNQ_Project_PRN222.Models;
using TrungNQ_Project_PRN222.Repositories;

namespace TrungNQ_Project_PRN222.Controllers
{
    public class AccountsController : Controller
    {
        
        private readonly AccountRepository _accountRepository;
        public AccountsController(AccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        // GET: Accounts
        public ActionResult Index()
        {
            var accountId = HttpContext.Session.GetString("AccountID");

            if (string.IsNullOrEmpty(accountId))
            {
                return RedirectToAction("Login", "Home"); // Chuyển hướng nếu chưa đăng nhập
            }

            var finder = _accountRepository.GetAccounts();
            return View(finder);
        }

        // GET: Accounts/Details/5
        public async Task<IActionResult> Details(int? id)
        {

            var accountId = HttpContext.Session.GetString("AccountID");

            if (string.IsNullOrEmpty(accountId))
            {
                return RedirectToAction("Login", "Home"); // Chuyển hướng nếu chưa đăng nhập
            }

            if (id == null)
            {
                return NotFound();
            }

            var account = _accountRepository.GetAccountById(id);
            if (account == null)
            {
                return NotFound();
            }

            return View(account);
        }

        // GET: Accounts/Create
        public ActionResult Create()
        {
            var accountId = HttpContext.Session.GetString("AccountID");

            if (string.IsNullOrEmpty(accountId))
            {
                return RedirectToAction("Login", "Home"); // Chuyển hướng nếu chưa đăng nhập
            }

            return View();
        }

        // POST: Accounts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Account account)
        {

            var accountId = HttpContext.Session.GetString("AccountID");

            if (string.IsNullOrEmpty(accountId))
            {
                return RedirectToAction("Login", "Home"); // Chuyển hướng nếu chưa đăng nhập
            }

            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
                foreach (var error in errors)
                {
                    Console.WriteLine(error);
                }

                return View(account);
            }
           

                _accountRepository.AddAccount(account);
                return RedirectToAction("Index");
        }

        // GET: Accounts/Edit/5
        public ActionResult Edit(int? id)
        {

            var accountId = HttpContext.Session.GetString("AccountID");

            if (string.IsNullOrEmpty(accountId))
            {
                return RedirectToAction("Login", "Home"); // Chuyển hướng nếu chưa đăng nhập
            }

            if (id == null)
            {
                return NotFound();
            }

            Account acc = _accountRepository.GetAccountById(id);
            if (acc == null)
            {
                return NotFound();
            }

            return View(acc);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public ActionResult Edit(int id, Account account)
        {

            var accountId = HttpContext.Session.GetString("AccountID");

            if (string.IsNullOrEmpty(accountId))
            {
                return RedirectToAction("Login", "Home"); // Chuyển hướng nếu chưa đăng nhập
            }

            if (id != account.AccountId)
            {
                return NotFound();
            }

            var existingAccount = _accountRepository.GetAccountById(id);


            if(existingAccount == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(account);
            }

            existingAccount.AccountId = account.AccountId;
            existingAccount.AccountStatus = account.AccountStatus;
            existingAccount.Role = account.Role;
            existingAccount.PhoneNumber = account.PhoneNumber;
            existingAccount.Password = account.Password;
            existingAccount.Email = account.Email;
            existingAccount.FullName = account.FullName;
            existingAccount.Username = account.Username;

            _accountRepository.UpdateAccount(existingAccount);

            return RedirectToAction("Index");
        }

        // GET: Accounts/Delete/5
        public ActionResult Delete(int? id)
        {
            var accountId = HttpContext.Session.GetString("AccountID");

            if (string.IsNullOrEmpty(accountId))
            {
                return RedirectToAction("Login", "Account"); // Chuyển hướng nếu chưa đăng nhập
            }
            return View();
        }

        // POST: Accounts/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, IFormCollection collection)
        {
            var accountId = HttpContext.Session.GetString("AccountID");

            if (string.IsNullOrEmpty(accountId))
            {
                return RedirectToAction("Login", "Home"); // Chuyển hướng nếu chưa đăng nhập
            }

            var account =  _accountRepository.GetAccountById(id);
            if (account == null)
            {
                return NotFound();
            }

            _accountRepository.DeleteAccount(id);
            return RedirectToAction("Index");
        }

        //private bool AccountExists(int id)
        //{
        //    return _context.Accounts.Any(e => e.AccountId == id);
        //}
    }
}
