using CORE.Models;
using INFRA.Infrastructure;
using INFRA.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace SERVICE.Core
{
    public interface IRoleService
    {
        Role GetRole(int id);
        void CreateRole(Role role);
        void SaveRole();
        void Update(Role role);
        void Delete(Role role);
        Role GetRole(string name);
    }

    public class RoleService : IRoleService
    {
        private readonly IRoleRepository roleRepository;
        private readonly IUnitOfWork unitOfWork;

        public RoleService(IRoleRepository roleRepository, IUnitOfWork unitOfWork)
        {
            this.roleRepository = roleRepository;
            this.unitOfWork = unitOfWork;
        }

        public void CreateRole(Role role)
        {
            roleRepository.Add(role);
            SaveRole();
        }

        public void Delete(Role role)
        {
            roleRepository.Delete(role);
            SaveRole();
        }

        public Role GetRole(int id)
        {
            return roleRepository.GetById(id);
        }

        public Role GetRole(string name)
        {
            return roleRepository.GetByName(name);
        }

        public void SaveRole()
        {
            unitOfWork.Commit();
        }

        public void Update(Role role)
        {
            roleRepository.Update(role);
            SaveRole();
        }
    }
}
