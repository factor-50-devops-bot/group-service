﻿using Castle.Core.Logging;
using GroupService.AzureFunction;
using GroupService.Handlers;
using HelpMyStreet.Contracts.GroupService.Request;
using HelpMyStreet.Contracts.GroupService.Response;
using HelpMyStreet.Contracts.RequestService.Response;
using HelpMyStreet.Contracts.Shared;
using HelpMyStreet.Utils.Utils;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GroupService.UnitTests.AzureFunctions
{
    public class PostCreateGroupTests
    {
        private Mock<IMediator> _mediator;
        private Mock<ILoggerWrapper<PostCreateGroupRequest>> _logger;
        private PostCreateGroup _classUnderTest;
        private PostCreateGroupResponse _response;

        [SetUp]
        public void Setup()
        {
            _logger = new Mock<ILoggerWrapper<PostCreateGroupRequest>>();
            _mediator = new Mock<IMediator>();
            _mediator.Setup(x => x.Send(It.IsAny<PostCreateGroupRequest>(), It.IsAny<CancellationToken>())).ReturnsAsync(()=> _response);
            _classUnderTest = new PostCreateGroup(_mediator.Object,_logger.Object);

        }

        [Test]
        public async Task HappyPath_ReturnsGroupId()
        {
            int groupId = 1;
            _response = new PostCreateGroupResponse()
            {
                GroupId = groupId
            };

            IActionResult result = await _classUnderTest.Run(new PostCreateGroupRequest()
            {
                GroupName = "Group"
            },CancellationToken.None);

            OkObjectResult objectResult = result as OkObjectResult;
            Assert.IsNotNull(objectResult);
            Assert.AreEqual(200, objectResult.StatusCode);

            ResponseWrapper<PostCreateGroupResponse, GroupServiceErrorCode> deserialisedResponse = objectResult.Value as ResponseWrapper<PostCreateGroupResponse, GroupServiceErrorCode>;
            Assert.IsNotNull(deserialisedResponse);

            Assert.IsTrue(deserialisedResponse.HasContent);
            Assert.IsTrue(deserialisedResponse.IsSuccessful);
            Assert.AreEqual(0, deserialisedResponse.Errors.Count());
            Assert.AreEqual(groupId, deserialisedResponse.Content.GroupId);

            _mediator.Verify(x => x.Send(It.IsAny<PostCreateGroupRequest>(), It.IsAny<CancellationToken>()),Times.Once);
        }

        [Test]
        public async Task MissingGroupName_ThrowsValidationError()
        {
            PostCreateGroupRequest req = new PostCreateGroupRequest();

            IActionResult result = await _classUnderTest.Run(req, CancellationToken.None);

            ObjectResult objectResult = result as ObjectResult;
            Assert.IsNotNull(objectResult);
            Assert.AreEqual(422, objectResult.StatusCode);

            ResponseWrapper<PostCreateGroupResponse, GroupServiceErrorCode> deserialisedResponse = objectResult.Value as ResponseWrapper<PostCreateGroupResponse, GroupServiceErrorCode>;
            Assert.IsNotNull(deserialisedResponse);

            Assert.IsFalse(deserialisedResponse.HasContent);
            Assert.IsFalse(deserialisedResponse.IsSuccessful);
            Assert.AreEqual(1, deserialisedResponse.Errors.Count());
            Assert.AreEqual(GroupServiceErrorCode.ValidationError, deserialisedResponse.Errors[0].ErrorCode);

            _mediator.Verify(x => x.Send(It.IsAny<PostCreateGroupRequest>(), It.IsAny<CancellationToken>()), Times.Never);
        }

        [Test]
        public async Task ExistingGroupName_ThrowsError()
        {
            string groupName = "Group";
            _mediator.Setup(x => x.Send(It.IsAny<PostCreateGroupRequest>(), It.IsAny<CancellationToken>()))
                .ThrowsAsync(new Exception($"{groupName} already exists as a group"));

            PostCreateGroupRequest req = new PostCreateGroupRequest() { GroupName = groupName };

            IActionResult result = await _classUnderTest.Run(req, CancellationToken.None);

            ObjectResult objectResult = result as ObjectResult;
            Assert.IsNotNull(objectResult);
            Assert.AreEqual(500, objectResult.StatusCode);

            ResponseWrapper<PostCreateGroupResponse, GroupServiceErrorCode> deserialisedResponse = objectResult.Value as ResponseWrapper<PostCreateGroupResponse, GroupServiceErrorCode>;
            Assert.IsNotNull(deserialisedResponse);

            Assert.IsFalse(deserialisedResponse.HasContent);
            Assert.IsFalse(deserialisedResponse.IsSuccessful);
            Assert.AreEqual(1, deserialisedResponse.Errors.Count());
            Assert.AreEqual(GroupServiceErrorCode.InternalServerError, deserialisedResponse.Errors[0].ErrorCode);

            _mediator.Verify(x => x.Send(It.IsAny<PostCreateGroupRequest>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Test]
        public async Task UnknownParentGroupName_ThrowsError()
        {
            string groupName = "Group";
            string parentGroupName = "ParentGroup";
            _mediator.Setup(x => x.Send(It.IsAny<PostCreateGroupRequest>(), It.IsAny<CancellationToken>()))
                            .ThrowsAsync(new Exception($"{parentGroupName} does not exists as a group and cannot therefore be linked as a parent group"));

            PostCreateGroupRequest req = new PostCreateGroupRequest() { GroupName = groupName, ParentGroupName= parentGroupName };

            IActionResult result = await _classUnderTest.Run(req, CancellationToken.None);

            ObjectResult objectResult = result as ObjectResult;
            Assert.IsNotNull(objectResult);
            Assert.AreEqual(500, objectResult.StatusCode);

            ResponseWrapper<PostCreateGroupResponse, GroupServiceErrorCode> deserialisedResponse = objectResult.Value as ResponseWrapper<PostCreateGroupResponse, GroupServiceErrorCode>;
            Assert.IsNotNull(deserialisedResponse);

            Assert.IsFalse(deserialisedResponse.HasContent);
            Assert.IsFalse(deserialisedResponse.IsSuccessful);
            Assert.AreEqual(1, deserialisedResponse.Errors.Count());
            Assert.AreEqual(GroupServiceErrorCode.InternalServerError, deserialisedResponse.Errors[0].ErrorCode);

            _mediator.Verify(x => x.Send(It.IsAny<PostCreateGroupRequest>(), It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
