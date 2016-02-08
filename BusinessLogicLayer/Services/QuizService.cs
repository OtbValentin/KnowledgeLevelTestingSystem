﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayer.API;
using BusinessLogicLayer.API.Services;
using BusinessLogicLayer.API.Entities;
using DataAccessLayer.API;
using BusinessLogicLayer.Mappers;

namespace BusinessLogicLayer.Services
{
    public class QuizService : IQuizService
    {
        private readonly IUnitOfWork uow;

        public QuizService(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public IEnumerable<Quiz> GetAll()
        {
            return uow.TestRepository.GetAll().Select(dalTest => dalTest.ToBllTest());
        }

        public void Create(Quiz entity)
        {
            uow.TestRepository.Create(entity.ToDalTest());
            uow.SaveChanges();
        }

        public void Delete(Quiz entity)
        {
            uow.TestRepository.Delete(entity.ToDalTest());
            uow.SaveChanges();
        }

        public Quiz GetById(int id)
        {
            return uow.TestRepository.GetById(id).ToBllTest();
        }
    }
}