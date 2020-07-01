﻿using AutoMapper;
using GroupService.Core.Dto;
using GroupService.Core.Interfaces.Repositories;
using GroupService.Repo.EntityFramework.Entities;
using HelpMyStreet.Contracts.GroupService.Request;
using HelpMyStreet.Utils.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;

namespace GroupService.Repo
{
    public class Repository : IRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public Repository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> AssignRoleAsync(PostAssignRoleRequest request, CancellationToken cancellationToken)
        {
            bool success = false;

            var group = _context.Group.FirstOrDefault(w => w.Id == request.GroupID);

            if (group == null)
                return false;

            _context.UserRole.Add(new UserRole()
            {
                GroupId = request.GroupID.Value,
                UserId = request.UserID.Value,
                RoleId = (int)request.Role.GroupRole
            });
            int result = await _context.SaveChangesAsync(cancellationToken);
            if (result == 1)
            {
                success = true;
            }
            
            return success;
        }
        public async Task<int> CreateGroupAsync(PostCreateGroupRequest request, CancellationToken cancellationToken)
        {
            int? parentGroupId = null;
            
            var group = _context.Group.FirstOrDefault(x => x.GroupName == request.GroupName && x.GroupKey == request.GroupKey);

            if (group != null)
            {
                throw new Exception($"GroupName {request.GroupName} or GroupKey {request.GroupKey} already exists as a group");
            }

            Group parentGroup = null;

            if(request.ParentGroupName!=null)
            {
                parentGroup = _context.Group.FirstOrDefault(x => x.GroupName == request.ParentGroupName);
                if (group == null)
                {
                    throw new Exception($"{request.ParentGroupName} does not exists as a group and cannot therefore be linked as a parent group");
                }
                parentGroupId = parentGroup.Id;
            }

            Group g = new Group()
            {
                GroupName = request.GroupName,
                GroupKey = request.GroupKey,
                ParentGroupId = parentGroupId
            };
            _context.Group.Add(g);
            await _context.SaveChangesAsync(cancellationToken);
            return g.Id;         
        }

        public List<int> GetUserGroups(GetUserGroupsRequest request, CancellationToken cancellationToken)
        {
            return _context.UserRole
                .Where(w => w.UserId == request.UserID)
                .Select(s => s.GroupId).ToList();
        }

        public Dictionary<int, List<int>> GetUserRoles(GetUserRolesRequest request, CancellationToken cancellationToken)
        {
            Dictionary<int, List<int>> response = new Dictionary<int, List<int>>();

            var roles = _context.UserRole
                .Where(w => w.UserId == request.UserID).ToList();

            List<int> distinctGroups = roles
                .Select(r => r.GroupId)
                .Distinct()
                .ToList();

            foreach (int i in distinctGroups)
            {
                response.Add(i, roles.Where(w => w.GroupId == i).Select(x=>x.RoleId).ToList());
            }
            return response;
        }

        public async Task<bool> RevokeRoleAsync(PostRevokeRoleRequest request, CancellationToken cancellationToken)
        {
            bool success = false;
            
            _context.UserRole.Remove(_context.UserRole.First(
            w => w.UserId == request.UserID.Value &&
            w.GroupId == request.GroupID.Value &&
            w.RoleId == (int)request.Role.GroupRole));

            int result = await _context.SaveChangesAsync(cancellationToken);
            if (result == 1)
            {
                success = true;
            }
            return success;
        }

        public async Task AddUserRoleAuditAsync(int groupId, int userId, GroupRoles groupRole, int authorisedByUserID, GroupAction groupAction, bool success, CancellationToken cancellationToken)
        {
            _context.UserRoleAudit.Add(new UserRoleAudit()
            {
                DateRequested = DateTime.Now.ToUniversalTime(),
                GroupId = groupId,
                UserId = userId,
                RoleId = (int)groupRole,
                AuthorisedByUserId = authorisedByUserID,
                ActionId = (byte) groupAction,
                Success = success
            });
            await _context.SaveChangesAsync(cancellationToken);
        }

        public bool RoleAssigned(int userId, int groupId, GroupRoles groupRole, CancellationToken cancellationToken)
        {
            UserRole role = _context.UserRole.FirstOrDefault(
                w => w.UserId == userId &&
                w.GroupId == groupId &&
                w.RoleId == (int)groupRole
                );

            if(role!=null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<int> GetGroupMembers(GetGroupMembersRequest request, CancellationToken cancellationToken)
        {
            return _context.UserRole
                .Where(w => w.GroupId == request.GroupID)
                .Select(s => s.UserId)
                .Distinct().ToList();
        }

        public int GetGroupByKey(GetGroupByKeyRequest request, CancellationToken cancellationToken)
        {
            var group = _context.Group.FirstOrDefault(w => w.GroupKey == request.GroupKey);
            if (group != null)
            {
                return group.Id;
            }
            else
            {
                throw new Exception($"{request.GroupKey} not found");
            }
        }
    }
}
