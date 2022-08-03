using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.UI;
using EmployeeMgt.HR.Employee.Dto;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMgt.HR.Employee
{
    public class EmployeeAppService : AsyncCrudAppService<MstEmployee, EmployeeDto>, IEmployeeAppService
    {
        private readonly IRepository<MstEmployee> _msEmployeeRepo;

        public EmployeeAppService(IRepository<MstEmployee> repository)
        : base(repository)
        {
            _msEmployeeRepo = repository;
        }

        [UnitOfWork(isTransactional: true)]
        public void CreateMsEmployee(EmployeeDto input)
        {
            Logger.Info("CreateEmployee() - Started.");
            Logger.DebugFormat("CreateEmployee() - Start checking before insert Employee. Parameters sent:{0}" +
                        "Code = {1}{0}" +
                        "Name = {2}{0}"
                        , Environment.NewLine, input.Id);

            var checkEmployee = (from A in _msEmployeeRepo.GetAll()
                                 where A.Id == input.Id
                                 select A).Any();

            Logger.DebugFormat("CreateEmployee() - Ended checking before insert Employee. Result = {0}", checkEmployee);

            if (!checkEmployee)
            {
                var createMstEmployee = new MstEmployee
                {
                    Id = input.Id,
                    UserName = input.UserName,
                    FirstName = input.FirstName,
                    LastName = input.LastName,
                    Email = input.Email,
                    BirthDate = input.BirthDate,
                    BasicSalary = input.BasicSalary,
                    Status = input.Status,
                    Group = input.Group,
                    Description = input.Description
                };

                try
                {
                    _msEmployeeRepo.Insert(createMstEmployee);
                    CurrentUnitOfWork.SaveChanges(); //execution saved inside try

                    Logger.DebugFormat("CreateMsEmployee() - Ended insert Employee.");
                }
                catch (DataException ex)
                {
                    Logger.ErrorFormat("CreateMsEmployee() - ERROR DataException. Result = {0}", ex.Message);
                    throw new UserFriendlyException("Db Error: " + ex.Message);
                }
                catch (Exception ex)
                {
                    Logger.ErrorFormat("CreateMsEmployee() - ERROR Exception. Result = {0}", ex.Message);
                    throw new UserFriendlyException("Error: " + ex.Message);
                }
            }
            else
            {
                Logger.ErrorFormat("CreateMsEmployee() - ERROR Result = {0}.", "Employee Name Already Exist !");
                throw new UserFriendlyException("Employee Name Already Exist !");
            }
            Logger.Info("CreateMsEmployee() - Finished.");
        }

        [UnitOfWork(isTransactional: true)]
        public JObject UpdateMsEmployee(EmployeeDto input)
        {
            Logger.Info("UpdateMsEmployee() - Started.");
            Logger.DebugFormat("UpdateMsEmployee() - Start checking before update Employee. Parameters sent:{0}" +
                        "EmployeeID = {1}{0}" +
                        "EmployeeCode = {2}{0}" +
                        "EmployeeName = {3}{0}"
                        , Environment.NewLine, input.Id);

            JObject obj = new JObject();

            var checkEmployee = (from A in _msEmployeeRepo.GetAll()
                                 where A.Id != input.Id// && (A.Name == input.Name)
                                 select A).Any();
            Logger.DebugFormat("UpdateMsEmployee() - Ended checking MS_Employee before update Employee. Result = {0}", checkEmployee);

            if (checkEmployee)
            {
                Logger.DebugFormat("UpdateMsEmployee() - Start get data before update Employee. Parameters sent:{0}" +
                            "EmployeeID = {1}{0}"
                            , Environment.NewLine, input.Id);

                var getMsEmployee = (from A in _msEmployeeRepo.GetAll()
                                     where input.Id == A.Id
                                     select A).FirstOrDefault();

                Logger.DebugFormat("UpdateMsEmployee() - Ended get data before update Employee.");

                var update = getMsEmployee.MapTo<MstEmployee>();

                update.Id = input.Id;
                update.UserName = input.UserName;
                update.FirstName = input.FirstName;
                update.LastName = input.LastName;
                update.Email = input.Email;
                update.BirthDate = input.BirthDate;
                update.BasicSalary = input.BasicSalary;
                update.Status = input.Status;
                update.Group = input.Group;
                update.Description = input.Description;

                if (!checkEmployee)
                {
                    update.Id = input.Id;
                    update.UserName = input.UserName;
                    update.FirstName = input.FirstName;
                    update.LastName = input.LastName;
                    update.Email = input.Email;
                    update.BirthDate = input.BirthDate;
                    update.BasicSalary = input.BasicSalary;
                    update.Status = input.Status;
                    update.Group = input.Group;
                    update.Description = input.Description;

                    obj.Add("message", "Edit Successfully");
                }
                else
                {
                    obj.Add("message", "Edit Successfully, but can't change Employee Name & Code");
                }

                try
                {
                    _msEmployeeRepo.Update(update);
                    CurrentUnitOfWork.SaveChanges(); //execution saved inside try

                    Logger.DebugFormat("UpdateMsEmployee() - Ended update Employee.");
                }
                catch (DataException ex)
                {
                    Logger.ErrorFormat("UpdateMsEmployee() - ERROR DataException. Result = {0}", ex.Message);
                    throw new UserFriendlyException("Db Error: " + ex.Message);
                }
                catch (Exception ex)
                {
                    Logger.ErrorFormat("UpdateMsEmployee() - ERROR Exception. Result = {0}", ex.Message);
                    throw new UserFriendlyException("Error: " + ex.Message);
                }
            }
            else
            {
                Logger.ErrorFormat("UpdateMsEmployee() - ERROR Result = {0}.", "Employee Code or Employee Name Already Exist !");
                throw new UserFriendlyException("Employee Code or Employee Name Already Exist !");
            }
            Logger.Info("UpdateMsEmployee() - Finished.");
            return obj;
        }

        [UnitOfWork(isTransactional: false)]
        public PagedResultDto<EmployeeDto> GetByUserName(PagedResultRequestDto data, string userName)
        {
            var dataCount = _msEmployeeRepo.Count();

            data.MaxResultCount = 10;
            data.SkipCount = 0;

            var getData = (from input in _msEmployeeRepo.GetAll()
                                 select new EmployeeDto
                                 {
                                     Id = input.Id,
                                     UserName = input.UserName,
                                     FirstName = input.FirstName,
                                     LastName = input.LastName,
                                     Email = input.Email,
                                     BirthDate = input.BirthDate,
                                     BasicSalary = input.BasicSalary,
                                     Status = input.Status,
                                     Group = input.Group,
                                     Description = input.Description

                                 })
                                .Where(w=>w.UserName.Contains(userName))
                                //.Skip(data.SkipCount)
                                //.Take(data.MaxResultCount)
                                .ToList();

            return new PagedResultDto<EmployeeDto>
            {
                TotalCount = dataCount,
                Items = getData.MapTo<List<EmployeeDto>>()
            };
        }

        [UnitOfWork(isTransactional: false)]
        public PagedResultDto<EmployeeDto> GetByGroup(PagedResultRequestDto data, string group)
        {
            var dataCount = _msEmployeeRepo.Count();

            //data.MaxResultCount = 1;
            //data.SkipCount = 0;

            var getData = (from input in _msEmployeeRepo.GetAll()
                           select new EmployeeDto
                           {
                               Id = input.Id,
                               UserName = input.UserName,
                               FirstName = input.FirstName,
                               LastName = input.LastName,
                               Email = input.Email,
                               BirthDate = input.BirthDate,
                               BasicSalary = input.BasicSalary,
                               Status = input.Status,
                               Group = input.Group,
                               Description = input.Description

                           })
                                .Where(w => w.Group.Contains(group))
                                //.Skip(data.SkipCount)
                                //.Take(data.MaxResultCount)
                                .ToList();

            return new PagedResultDto<EmployeeDto>
            {
                TotalCount = dataCount,
                Items = getData.MapTo<List<EmployeeDto>>()
            };
        }
    }
}
