﻿using GroupService.Repo.EntityFramework.Entities;
using HelpMyStreet.Utils.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GroupService.Repo.Helpers
{
    public static class SecurityConfigurationExtensions
    {
        public static void SetDefaultSecurityConfiguration(this EntityTypeBuilder<SecurityConfiguration> entity)
        {
            entity.HasData(new SecurityConfiguration
            {
                GroupId = (int)Groups.Ruddington,
                AllowAutonomousJoinersAndLeavers = true
            });
        }
    }
}
