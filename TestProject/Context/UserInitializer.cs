﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TestProject.Context
{
    public class UserInitializer : DropCreateDatabaseAlways<DBAContext>
    {
        protected override void Seed(DBAContext db)
        {
            db.Users.Add(new Models.User {Id=1, Email = "fdfd@mail.ru", FirstName = "aaa", LastName="dss", Position=  Enum.PositionEnum.Position.Developer });
            db.Users.Add(new Models.User { Id = 1, Email = "first@mail.ru", FirstName = "first", LastName = "firstUser", Position =  Enum.PositionEnum.Position.PM });
            db.Users.Add(new Models.User { Id = 1, Email = "second@mail.ru", FirstName = "second", LastName = "secondUser", Position =  Enum.PositionEnum.Position.QA });

            base.Seed(db);
        }
    }
}