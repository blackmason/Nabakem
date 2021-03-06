﻿using NABAKEM.Models.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NABAKEM.Controllers
{
    public class AdminController : RootController
    {
        /// <summary>
        /// 관리자화면
        /// 요약화면
        /// </summary>
        /// <returns></returns>
        public ActionResult Summary()
        {
            return View();
        }

        /// <summary>
        /// 관리자화면
        /// 제품관리
        /// </summary>
        /// <returns></returns>
        public ActionResult Products(string id)
        {
            if ("List" == id)
            {
                return View("Product/List");
            }
            else if ("Add" == id)
            {
                return View("Product/Add");
            }
            else if ("Update" == id)
            {
                return View("Product/Update");
            }
            else
            {
                return RedirectToAction("Summary");
            }
        }


        /// <summary>
        /// 메뉴관리
        /// 전체 메뉴를 가져온다.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Menus(string id)
        {
            if ("List" == id)
            {
                MenuHelper helper = new MenuHelper();
                var menus = helper.GetAllMenus();
                var groups = helper.GetAllMenuGroups();

                Dictionary<string, object> mg = new Dictionary<string, object>();
                mg.Add("menus", menus);
                mg.Add("groups", groups);

                return View("Menu/List", mg);
            }
            else
            {
                return RedirectToAction("Summary");
            }
        }

        /// <summary>
        /// 메뉴관리
        /// 선택한 메뉴정보를 가져온다
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public JsonResult GetMenu(string code)
        {
            MenuHelper helper = new MenuHelper();
            var result = helper.GetMenu(code);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 메뉴관리
        /// 선택한 메뉴를 수정한다.
        /// </summary>
        /// <param name="code"></param>
        /// <param name="name"></param>
        /// <param name="parentCode"></param>
        /// <param name="url"></param>
        /// <param name="authLevel"></param>
        /// <param name="isUse"></param>
        /// <param name="ordering"></param>
        /// <param name="comment"></param>
        public void UpdateMenu(string code, string name, string parentCode, string url, string isUse, string ordering, string comment)
        {
            MenuHelper helper = new MenuHelper();
            helper.UpdateMenu(code, name, parentCode, url, isUse, ordering, comment);
            return;
        }

        /// <summary>
        /// 메뉴관리
        /// 메뉴를 추가한다.
        /// </summary>
        /// <param name="code"></param>
        /// <param name="name"></param>
        /// <param name="parentCode"></param>
        /// <param name="url"></param>
        /// <param name="role"></param>
        /// <param name="isUse"></param>
        /// <param name="ordering"></param>
        /// <param name="comment"></param>
        public void AddMenu(string code, string name, string typeCode, string parentCode, string url, string isUse, string ordering, string comment)
        {
            MenuHelper helper = new MenuHelper();
            helper.AddMenu(code, name, typeCode, parentCode, url, isUse, ordering, comment);
            return;
        }

        /// <summary>
        /// 메뉴관리-메뉴그룹
        /// 전체 메뉴그룹을 가져온다.
        /// </summary>
        /// <param name="code"></param>
        /// <param name="name"></param>
        /// <param name="authLevel"></param>
        public ActionResult MenuGroup(string id)
        {
            MenuHelper helper = new MenuHelper();

            if ("List" == id)
            {
                var result = helper.GetAllMenuGroups();
                return View("MenuGroup/List", result);
            }
            else
            {
                var result = helper.GetAllMenuGroups();
                return View(result);
            }
        }

        /// <summary>
        /// 메뉴관리-메뉴그룹
        /// 선택한 메뉴그룹 정보를 가져온다.
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public JsonResult GetMenuGroup(string code)
        {
            MenuHelper helper = new MenuHelper();
            var result = helper.GetMenuGroup(code);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 메뉴관리-메뉴그룹
        /// 선택한 메뉴그룹 정보를 수정한다.
        /// </summary>
        /// <param name="code"></param>
        /// <param name="name"></param>
        /// <param name="isUse"></param>
        /// <param name="authLevel"></param>
        /// <param name="ordering"></param>
        /// <param name="comment"></param>
        /// <returns></returns>
        public void UpdateMenuGroup(string code, string name, string isUse, string authLevel, string ordering, string comment)
        {
            MenuHelper helper = new MenuHelper();
            helper.UpdateMenuGroup(code, name, isUse, authLevel, ordering, comment);
        }

        /// <summary>
        /// 메뉴관리-메뉴그룹
        /// 메뉴그룹 정보를 추가한다.
        /// </summary>
        /// <param name="code"></param>
        /// <param name="name"></param>
        /// <param name="isUse"></param>
        /// <param name="authLevel"></param>
        /// <param name="ordering"></param>
        /// <param name="comment"></param>
        public void AddMenuGroup(string code, string name, string isUse, string authLevel, string ordering, string comment)
        {
            MenuHelper helper = new MenuHelper();
            helper.AddMenuGroup(code, name, isUse, authLevel, ordering, comment);
        }

        /// <summary>
        /// 게시판관리
        /// 게시판목록
        /// </summary>
        /// <returns></returns>
        public ActionResult GetAllBoards()
        {
            return View("");
        }

        /// <summary>
        /// 사용자관리
        /// 사용자목록
        /// </summary>
        /// <returns></returns>
        public ActionResult GetAllUsers()
        {
            return View("");
        }


        /*
         * 게시판관리
         * 글 전체목록
         */
        public ActionResult GetAllArticle()
        {
            BoardHelper helper = new BoardHelper();
            var result = helper.GetAllArticle();
            return View("ArticleAll", result);
        }

        /*
         * 공지사항
         * 공지사항 추가
         * 모드
         */
        public ActionResult Notice(string mode)
        {
            if ("Write" == mode)
            {
                return RedirectToAction("Notice/Write", "BBS");
            }
            else
            {
                return RedirectToAction("Notice/List", "BBS");
            }
        }

        public JsonResult GetParentMenus()
        {
            MenuHelper helper = new MenuHelper();
            var parents = helper.GetParentMenus();
            return Json(parents, JsonRequestBehavior.AllowGet);
        }
    }
}
