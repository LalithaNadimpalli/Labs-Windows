// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting.AppContainer;
using System;
using System.Threading;

namespace CommunityToolkit.Labs.Uwp.UnitTests.ProjectTemplate
{
    /// <summary>
    /// UnitTests for the <see cref="CounterButton"/> control.
    /// </summary>
    [TestClass]
    public class CounterButtonTests
    {
        [UITestMethod]
        public void DefaultTest()
        {
            var cb = new CounterButton();
            var defaultCount = 0;
            var defaultStep = 1;

            Assert.AreEqual(defaultCount, cb.Count);
            Assert.AreEqual(defaultStep, cb.Step);
        }

        [UITestMethod]
        public void IncrementTest()
        {
            var cb = new CounterButton();
            var defaultCount = cb.Count;
            var defaultStep = cb.Step;
            var eventFired = false;

            cb.CountChanged += (s, e) =>
            {
                eventFired = true;
            };

            // Increment the Count by the Step
            cb.Increment();
            Assert.AreEqual(defaultCount + defaultStep, cb.Count);

            // Wait a second then ensure that the event fired.
            Thread.Sleep(TimeSpan.FromSeconds(1));
            Assert.IsTrue(eventFired);
        }

        [UITestMethod]
        public void StepTest()
        {
            var cb = new CounterButton();
            var defaultCount = cb.Count;
            var step = 10;

            // Set the Step
            cb.Step = step;

            // Increment the Count by the Step
            cb.Increment();
            Assert.AreEqual(defaultCount + step, cb.Count);
        }
    }
}
