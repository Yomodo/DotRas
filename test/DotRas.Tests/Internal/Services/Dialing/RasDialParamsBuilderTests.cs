﻿using System;
using System.Net;
using DotRas.Internal.Abstractions.Factories;
using DotRas.Internal.Abstractions.Services;
using DotRas.Internal.Services.Dialing;
using Moq;
using NUnit.Framework;

namespace DotRas.Tests.Internal.Services.Dialing
{
    [TestFixture]
    public class RasDialParamsBuilderTests
    {
        [Test]
        public void ThrowsAnExceptionWhenStructFactoryIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new RasDialParamsBuilder(null));
        }

        [Test]
        public void BuildsTheStructureWithTheEntryName()
        {
            var structFactory = new Mock<IStructFactory>();

            var context = new RasDialContext
            {
                EntryName = "Test"
            };

            var target = new RasDialParamsBuilder(structFactory.Object);
            var result = target.Build(context);

            Assert.AreEqual("Test", result.szEntryName);
        }

        [Test]
        public void BuildsTheStructureWithTheInterfaceIndex()
        {
            var structFactory = new Mock<IStructFactory>();

            var context = new RasDialContext
            {
                InterfaceIndex = 1
            };

            var target = new RasDialParamsBuilder(structFactory.Object);
            var result = target.Build(context);

            Assert.AreEqual(1, result.dwIfIndex);
        }

        [Test]
        public void BuildsTheStructureWithTheUserNameAndPassword()
        {
            var structFactory = new Mock<IStructFactory>();

            var context = new RasDialContext
            {
                Credentials = new NetworkCredential("User", "Pass")
            };

            var target = new RasDialParamsBuilder(structFactory.Object);
            var result = target.Build(context);

            Assert.AreEqual("User", result.szUserName);
            Assert.AreEqual("Pass", result.szPassword);
        }

        [Test]
        public void BuildsTheStructureWithTheUserNamePasswordAndDomain()
        {
            var structFactory = new Mock<IStructFactory>();

            var context = new RasDialContext
            {
                Credentials = new NetworkCredential("User", "Pass", "Domain")
            };

            var target = new RasDialParamsBuilder(structFactory.Object);
            var result = target.Build(context);

            Assert.AreEqual("User", result.szUserName);
            Assert.AreEqual("Pass", result.szPassword);
            Assert.AreEqual("Domain", result.szDomain);
        }
    }
}