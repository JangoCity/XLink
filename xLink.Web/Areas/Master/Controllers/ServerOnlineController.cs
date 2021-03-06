﻿using System;
using System.ComponentModel;
using System.Web.Mvc;
using NewLife.Cube;
using NewLife.Web;
using xLink.Master.Entity;

namespace xLink.Master.Web.Controllers
{
    [Description("服务器登录后产生在线记录，一般长期在线")]
    public class ServerOnlineController : EntityController<ServerOnline>
    {
        static ServerOnlineController()
        {
            ListFields.RemoveField("LastError");
        }

        /// <summary>列表页视图。子控制器可重载，以传递更多信息给视图，比如修改要显示的列</summary>
        /// <param name="p"></param>
        /// <returns></returns>
        protected override ActionResult IndexView(Pager p)
        {
            var list = ServerOnline.Search(p["Type"], p["dtStart"].ToDateTime(), p["dtEnd"].ToDateTime(), p["Q"], p);

            return View("List", list);
        }
    }
}