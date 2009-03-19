﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace System.ComponentModel.DataAnnotations.Test {
    [TestClass]
    public class RequiredAttributeTest {
        [TestMethod]
        public void IsValid() {
            RequiredAttribute required = new RequiredAttribute();

            Assert.AreEqual(true, required.IsValid("abcd"));
            Assert.AreEqual(true, required.IsValid("  ab  "));
            Assert.AreEqual(true, required.IsValid(10));

            Assert.AreEqual(false, required.IsValid(""));
            Assert.AreEqual(false, required.IsValid("   "));
            Assert.AreEqual(false, required.IsValid("\t"));
            Assert.AreEqual(false, required.IsValid(null));
        }

        [TestMethod]
        public void DefaultErrorMessage() {
            RequiredAttribute required = new RequiredAttribute();
            Assert.AreEqual("The SOME_NAME field is required.", required.FormatErrorMessage("SOME_NAME"));
        }
    }
}
