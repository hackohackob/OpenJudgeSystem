﻿namespace OJS.Web.Tests.Administration.TestsControllerTests
{
    using System.Web.Mvc;

    using NUnit.Framework;

    using OJS.Common;
    using OJS.Web.Areas.Administration.ViewModels.Test;

    [TestFixture]
    public class DetailsActionTests : TestsControllerBaseTestsClass
    {
        [Test]
        public void DetailsActionShouldReturnProperRedirectWhenIdIsNull()
        {
            var redirectResult = this.TestsController.Details(null) as RedirectToRouteResult;

            Assert.IsNotNull(redirectResult);
            Assert.AreEqual(GlobalConstants.Index, redirectResult.RouteValues["action"]);
        }

        [Test]
        public void DetailsActionShouldReturnProperMessageWhenIdIsNull()
        {
            var redirectResult = this.TestsController.Details(null) as RedirectToRouteResult;
            Assert.IsNotNull(redirectResult);

            var tempDataHasKey = this.TestsController.TempData.ContainsKey(GlobalConstants.DangerMessage);
            Assert.IsTrue(tempDataHasKey);

            var tempDataMessage = this.TestsController.TempData[GlobalConstants.DangerMessage];
            Assert.AreEqual("Невалиден тест", tempDataMessage);
        }

        [Test]
        public void DetailsActionShouldReturnProperRedirectWhenTestIsNull()
        {
            var redirectResult = this.TestsController.Details(100) as RedirectToRouteResult;

            Assert.IsNotNull(redirectResult);
            Assert.AreEqual(GlobalConstants.Index, redirectResult.RouteValues["action"]);
        }

        [Test]
        public void DetailsActionShouldReturnProperMessageWhenTestIsNull()
        {
            var redirectResult = this.TestsController.Details(100) as RedirectToRouteResult;
            Assert.IsNotNull(redirectResult);

            var tempDataHasKey = this.TestsController.TempData.ContainsKey(GlobalConstants.DangerMessage);
            Assert.IsTrue(tempDataHasKey);

            var tempDataMessage = this.TestsController.TempData[GlobalConstants.DangerMessage];
            Assert.AreEqual("Невалиден тест", tempDataMessage);
        }

        [Test]
        public void DetailsActionShouldReturnProperViewModelWhenIdIsCorrect()
        {
            var viewResult = this.TestsController.Details(1) as ViewResult;
            Assert.IsNotNull(viewResult);

            var model = viewResult.Model as TestViewModel;
            Assert.IsNotNull(model);

            Assert.AreEqual("Sample test input", model.InputFull);
            Assert.AreEqual("Sample test output", model.OutputFull);
            Assert.AreEqual(false, model.IsTrialTest);
            Assert.AreEqual(1, model.ProblemId);
            Assert.AreEqual(5, model.OrderBy);
        }
    }
}
