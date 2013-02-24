﻿using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace dokas.FluentStrings.Tests
{
    [TestClass]
    public class RemoveTests
    {
        #region Full Remove

        [TestMethod]
        public void RemoveFromNullString()
        {
            string transformed = Const.NullString.Remove();
            transformed.Should().Be(Const.NullString);
        }

        [TestMethod]
        public void RemoveFromEmptyString()
        {
            string transformed = String.Empty.Remove();
            transformed.Should().Be(String.Empty);
        }

        [TestMethod]
        public void Remove()
        {
            string transformed = "Some string".Remove();
            transformed.Should().Be(String.Empty);
        }

        #endregion

        #region Remove

        [TestMethod]
        public void RemoveTextFromNullString()
        {
            string transformed = Const.NullString.Remove("bla");
            transformed.Should().Be(Const.NullString);
        }

        [TestMethod]
        public void RemoveNullText()
        {
            string transformed = Const.SampleString.Remove(null);
            transformed.Should().Be(Const.SampleString);
        }

        [TestMethod]
        public void RemoveNullTextFromNullString()
        {
            string transformed = Const.NullString.Remove(null);
            transformed.Should().Be(Const.NullString);
        }

        [TestMethod]
        public void RemoveEmptyText()
        {
            string transformed = Const.SampleString.Remove(String.Empty);
            transformed.Should().Be(Const.SampleString);
        }

        [TestMethod]
        public void RemoveText()
        {
            string transformed = "TEST string will be removed".Remove("TEST");
            transformed.Should().Be(" string will be removed");

            transformed = "string will be removed ->TEST".Remove("TEST");
            transformed.Should().Be("string will be removed ->");

            transformed = "string will be removed ->TEST and this will be left TEST".Remove("TEST");
            transformed.Should().Be("string will be removed -> and this will be left TEST");

            transformed = "TEST string will be removed only from left side TEST".Remove("TEST");
            transformed.Should().Be(" string will be removed only from left side TEST");
        }

        [TestMethod]
        public void RemoveTextCaseSensitive()
        {
            string transformed = "tEsT string will be removed".Remove("tEsT");
            transformed.Should().Be(" string will be removed");

            transformed = "string will be removed ->TesT and this will be left TEST".Remove("TesT");
            transformed.Should().Be("string will be removed -> and this will be left TEST");

            transformed = "TEST string will be NOT be removed from string TEST".Remove("test");
            transformed.Should().Be("TEST string will be NOT be removed from string TEST");
        }

        #endregion

        #region Remove From

        [TestMethod]
        public void RemoveTextFromBeginningOfNullString()
        {
            string transformed = Const.NullString.Remove("bla").From(The.Beginning);
            transformed.Should().Be(Const.NullString);
        }

        [TestMethod]
        public void RemoveTextFromEndOfNullString()
        {
            string transformed = Const.NullString.Remove("bla").From(The.End);
            transformed.Should().Be(Const.NullString);
        }

        [TestMethod]
        public void RemoveNullTextFromBeginning()
        {
            string transformed = Const.SampleString.Remove(null).From(The.Beginning);
            transformed.Should().Be(Const.SampleString);
        }

        [TestMethod]
        public void RemoveNullTextFromEnd()
        {
            string transformed = Const.SampleString.Remove(null).From(The.End);
            transformed.Should().Be(Const.SampleString);
        }

        [TestMethod]
        public void RemoveNullTextFromBeginningOfNullString()
        {
            string transformed = Const.NullString.Remove(null).From(The.Beginning);
            transformed.Should().Be(Const.NullString);
        }

        [TestMethod]
        public void RemoveNullTextFromEndOfNullString()
        {
            string transformed = Const.NullString.Remove(null).From(The.End);
            transformed.Should().Be(Const.NullString);
        }

        [TestMethod]
        public void RemoveEmptyTextFromBeginning()
        {
            string transformed = Const.SampleString.Remove(String.Empty).From(The.Beginning);
            transformed.Should().Be(Const.SampleString);
        }

        [TestMethod]
        public void RemoveEmptyTextFromEnd()
        {
            string transformed = Const.SampleString.Remove(String.Empty).From(The.End);
            transformed.Should().Be(Const.SampleString);
        }

        [TestMethod]
        public void RemoveTextFromBeginning()
        {
            string transformed = "TEST string will be removed".Remove("TEST").From(The.Beginning);
            transformed.Should().Be(" string will be removed");

            transformed = "TEST <- string will be removed, not this -> TEST".Remove("TEST").From(The.Beginning);
            transformed.Should().Be(" <- string will be removed, not this -> TEST");

            transformed = "Some additional string |TEST| string will be removed".Remove("TEST").From(The.Beginning);
            transformed.Should().Be("Some additional string || string will be removed");
        }

        [TestMethod]
        public void RemoveTextCaseSensitiveFromBeginning()
        {
            string transformed = "teST string will be removed".Remove("teST").From(The.Beginning);
            transformed.Should().Be(" string will be removed");

            transformed = "test <- string will be removed, not this -> test".Remove("test").From(The.Beginning);
            transformed.Should().Be(" <- string will be removed, not this -> test");

            transformed = "Some additional TEST which will be ignored string |TeSt| string will be removed".Remove("TeSt").From(The.Beginning);
            transformed.Should().Be("Some additional TEST which will be ignored string || string will be removed");
        }

        [TestMethod]
        public void RemoveTextFromEnd()
        {
            string transformed = "string will be removed -> TEST".Remove("TEST").From(The.End);
            transformed.Should().Be("string will be removed -> ");

            transformed = "TEST <- this string will be left, but this will be removed -> TEST".Remove("TEST").From(The.End);
            transformed.Should().Be("TEST <- this string will be left, but this will be removed -> ");

            transformed = "string will be removed -> |TEST| some additional string".Remove("TEST").From(The.End);
            transformed.Should().Be("string will be removed -> || some additional string");
        }

        [TestMethod]
        public void RemoveTextCaseSensitiveFromEnd()
        {
            string transformed = "string will be removed -> TesT".Remove("TesT").From(The.End);
            transformed.Should().Be("string will be removed -> ");

            transformed = "test <- this string will be left, but this will be removed -> test".Remove("test").From(The.End);
            transformed.Should().Be("test <- this string will be left, but this will be removed -> ");

            transformed = "string will be removed -> |tEsT| some additional string".Remove("tEsT").From(The.End);
            transformed.Should().Be("string will be removed -> || some additional string");
        }

        #endregion

        #region Remove Ignoring Case

        [TestMethod]
        public void RemoveTextFromNullStringIgnoringCase()
        {
            string transformed = Const.NullString.Remove("bla").IgnoringCase();
            transformed.Should().Be(Const.NullString);
        }

        [TestMethod]
        public void RemoveNullTextIgnoringCase()
        {
            string transformed = Const.SampleString.Remove(null).IgnoringCase();
            transformed.Should().Be(Const.SampleString);
        }

        [TestMethod]
        public void RemoveNullTextFromNullStringIgnoringCase()
        {
            string transformed = Const.NullString.Remove(null).IgnoringCase();
            transformed.Should().Be(Const.NullString);
        }

        [TestMethod]
        public void RemoveEmptyTextIgnoringCase()
        {
            string transformed = Const.SampleString.Remove(String.Empty).IgnoringCase();
            transformed.Should().Be(Const.SampleString);
        }

        [TestMethod]
        public void RemoveTextIgnoringCase()
        {
            string transformed = "TEST string will be removed".Remove("TeSt").IgnoringCase();
            transformed.Should().Be(" string will be removed");

            transformed = "string will be removed ->tEST".Remove("tEsT").IgnoringCase();
            transformed.Should().Be("string will be removed ->");

            transformed = "string will be removed ->TEST and this will be left TEST".Remove("TEST").IgnoringCase();
            transformed.Should().Be("string will be removed -> and this will be left TEST");

            transformed = "TesT string will be removed only from left side TEST".Remove("TEST").IgnoringCase();
            transformed.Should().Be(" string will be removed only from left side TEST");
        }

        #endregion

        #region Remove Ignoring Case From

        [TestMethod]
        public void RemoveTextFromBeginningOfNullStringIgnoringCase()
        {
            string transformed = Const.NullString.Remove("bla").IgnoringCase().From(The.Beginning);
            transformed.Should().Be(Const.NullString);
        }

        [TestMethod]
        public void RemoveTextFromEndOfNullStringIgnoringCase()
        {
            string transformed = Const.NullString.Remove("bla").IgnoringCase().From(The.End);
            transformed.Should().Be(Const.NullString);
        }

        [TestMethod]
        public void RemoveNullTextFromBeginningIgnoringCase()
        {
            string transformed = Const.SampleString.Remove(null).IgnoringCase().From(The.Beginning);
            transformed.Should().Be(Const.SampleString);
        }

        [TestMethod]
        public void RemoveNullTextFromEndIgnoringCase()
        {
            string transformed = Const.SampleString.Remove(null).IgnoringCase().From(The.End);
            transformed.Should().Be(Const.SampleString);
        }

        [TestMethod]
        public void RemoveNullTextFromBeginningOfNullStringIgnoringCase()
        {
            string transformed = Const.NullString.Remove(null).IgnoringCase().From(The.Beginning);
            transformed.Should().Be(Const.NullString);
        }

        [TestMethod]
        public void RemoveNullTextFromEndOfNullStringIgnoringCase()
        {
            string transformed = Const.NullString.Remove(null).IgnoringCase().From(The.End);
            transformed.Should().Be(Const.NullString);
        }

        [TestMethod]
        public void RemoveEmptyTextFromBeginningIgnoringCase()
        {
            string transformed = Const.SampleString.Remove(String.Empty).IgnoringCase().From(The.Beginning);
            transformed.Should().Be(Const.SampleString);
        }

        [TestMethod]
        public void RemoveEmptyTextFromEndIgnoringCase()
        {
            string transformed = Const.SampleString.Remove(String.Empty).IgnoringCase().From(The.End);
            transformed.Should().Be(Const.SampleString);
        }

        [TestMethod]
        public void RemoveTextFromBeginningIgnoringCase()
        {
            string transformed = "TEST string will be removed".Remove("TeSt").IgnoringCase().From(The.Beginning);
            transformed.Should().Be(" string will be removed");

            transformed = "string will be removed ->tEST".Remove("tEsT").IgnoringCase().From(The.Beginning);
            transformed.Should().Be("string will be removed ->");

            transformed = "string will be removed ->TEST and this will be left TEST".Remove("TEST").IgnoringCase().From(The.Beginning);
            transformed.Should().Be("string will be removed -> and this will be left TEST");

            transformed = "TesT string will be removed only from left side TEST".Remove("TEST").IgnoringCase().From(The.Beginning);
            transformed.Should().Be(" string will be removed only from left side TEST");
        }

        [TestMethod]
        public void RemoveTextFromEndIgnoringCase()
        {
            string transformed = "string will be removed -> TEST".Remove("tESt").IgnoringCase().From(The.End);
            transformed.Should().Be("string will be removed -> ");

            transformed = "TEST <- this string will be left, but this will be removed -> TEST".Remove("test").IgnoringCase().From(The.End);
            transformed.Should().Be("TEST <- this string will be left, but this will be removed -> ");

            transformed = "string will be removed -> |TesT| some additional string".Remove("TEST").IgnoringCase().From(The.End);
            transformed.Should().Be("string will be removed -> || some additional string");
        }

        #endregion

        #region Remove Values

        [TestMethod]
        public void RemoveValuesFromNullString()
        {
            string transformed = Const.NullString.Remove(2, "bla");
            transformed.Should().Be(Const.NullString);
        }

        [TestMethod]
        public void RemoveNullValues()
        {
            string transformed = Const.SampleString.Remove(3, null);
            transformed.Should().Be(Const.SampleString);
        }

        [TestMethod]
        public void RemoveNullValuesFromNullString()
        {
            string transformed = Const.NullString.Remove(1, null);
            transformed.Should().Be(Const.NullString);
        }

        [TestMethod]
        public void RemoveEmptyValues()
        {
            string transformed = Const.SampleString.Remove(2, String.Empty);
            transformed.Should().Be(Const.SampleString);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void RemoveNegativeQuantityValues()
        {
            string transformed = Const.SampleString.Remove(-1, "TEST");
        }

        [TestMethod]
        public void RemoveZeroValues()
        {
            string transformed = Const.SampleString.Remove(0, "TEST");
            transformed.Should().Be(Const.SampleString);
        }

        [TestMethod]
        public void RemoveOneValue()
        {
            string transformed = "TEST string will be removed".Remove(1, "TEST");
            transformed.Should().Be(" string will be removed");

            transformed = "string will be removed ->TEST".Remove(1, "TEST");
            transformed.Should().Be("string will be removed ->");
        }

        [TestMethod]
        public void RemoveTwoValues()
        {
            string transformed = "string will be removed ->TEST and this will be removed also TEST".Remove(2, "TEST");
            transformed.Should().Be("string will be removed -> and this will be removed also ");
        }

        [TestMethod]
        public void RemoveThreeValuesFromStringWithFourValues()
        {
            string transformed = "TEST only three TEST strings will be removed from TEST string TEST".Remove(3, "TEST");
            transformed.Should().Be(" only three  strings will be removed from  string TEST");
        }

        [TestMethod]
        public void RemoveOneValueCaseSensitive()
        {
            string transformed = "TEsT string will be removed".Remove(1, "TEsT");
            transformed.Should().Be(" string will be removed");

            transformed = "string will be removed ->Test".Remove(1, "Test");
            transformed.Should().Be("string will be removed ->");
        }

        [TestMethod]
        public void RemoveThreeValuesCaseSensitiveFromStringWithFourValues()
        {
            string transformed = "TesT only three TesT strings will be removed from TesT string TesT".Remove(3, "TesT");
            transformed.Should().Be(" only three  strings will be removed from  string TesT");
        }

        #endregion

        #region Remove Values From

        [TestMethod]
        public void RemoveValuesFromBeginningOfNullString()
        {
            string transformed = Const.NullString.Remove(2, "bla").From(The.Beginning);
            transformed.Should().Be(Const.NullString);
        }

        [TestMethod]
        public void RemoveValuesFromEndOfNullString()
        {
            string transformed = Const.NullString.Remove(4, "bla").From(The.End);
            transformed.Should().Be(Const.NullString);
        }

        [TestMethod]
        public void RemoveNullValuesFromBeginning()
        {
            string transformed = Const.SampleString.Remove(2, null).From(The.Beginning);
            transformed.Should().Be(Const.SampleString);
        }

        [TestMethod]
        public void RemoveNullValuesFromEnd()
        {
            string transformed = Const.SampleString.Remove(2, null).From(The.End);
            transformed.Should().Be(Const.SampleString);
        }

        [TestMethod]
        public void RemoveNullValuesFromBeginningOfNullString()
        {
            string transformed = Const.NullString.Remove(4, null).From(The.Beginning);
            transformed.Should().Be(Const.NullString);
        }

        [TestMethod]
        public void RemoveNullValuesFromEndOfNullString()
        {
            string transformed = Const.NullString.Remove(2, null).From(The.End);
            transformed.Should().Be(Const.NullString);
        }

        [TestMethod]
        public void RemoveEmptyValuesFromBeginning()
        {
            string transformed = Const.SampleString.Remove(2, String.Empty).From(The.Beginning);
            transformed.Should().Be(Const.SampleString);
        }

        [TestMethod]
        public void RemoveEmptyValuesFromEnd()
        {
            string transformed = Const.SampleString.Remove(1, String.Empty).From(The.End);
            transformed.Should().Be(Const.SampleString);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void RemoveNegativeQuantityValuesFromBeginning()
        {
            string transformed = "TEST string will be removed".Remove(-1, "TEST").From(The.Beginning);
        }

        [TestMethod]
        public void RemoveZeroValuesFromBeginning()
        {
            string transformed = "TEST string will be removed".Remove(0, "TEST").From(The.Beginning);
            transformed.Should().Be("TEST string will be removed");

            transformed = "TEST <- both strings will be removed -> TEST".Remove(0, "TEST").From(The.Beginning);
            transformed.Should().Be("TEST <- both strings will be removed -> TEST");
        }

        [TestMethod]
        public void RemoveValuesFromBeginning()
        {
            string transformed = "TEST string will be removed".Remove(1, "TEST").From(The.Beginning);
            transformed.Should().Be(" string will be removed");

            transformed = "TEST <- both strings will be removed -> TEST".Remove(2, "TEST").From(The.Beginning);
            transformed.Should().Be(" <- both strings will be removed -> ");

            transformed = "Some additional string |TEST| string will be removed".Remove(1, "TEST").From(The.Beginning);
            transformed.Should().Be("Some additional string || string will be removed");
        }

        [TestMethod]
        public void RemoveManyValuesFromBeginning()
        {
            string transformed = "TEST <- both strings will be removed -> TEST, but this TEST will be left".Remove(2, "TEST").From(The.Beginning);
            transformed.Should().Be(" <- both strings will be removed -> , but this TEST will be left");

            transformed = "these will be removed -> TEST, TEST, TEST, TEST and these will survive TEST, TEST, TEST".Remove(4, "TEST").From(The.Beginning);
            transformed.Should().Be("these will be removed -> , , ,  and these will survive TEST, TEST, TEST");
        }

        [TestMethod]
        public void RemoveValuesCaseSensitiveFromBeginning()
        {
            string transformed = "teST string will be removed".Remove(1, "teST").From(The.Beginning);
            transformed.Should().Be(" string will be removed");

            transformed = "test <- string will be removed, not this -> test".Remove(1, "test").From(The.Beginning);
            transformed.Should().Be(" <- string will be removed, not this -> test");

            transformed = "Some additional TEST which will be ignored string |TeSt| string will be removed".Remove(1, "TeSt").From(The.Beginning);
            transformed.Should().Be("Some additional TEST which will be ignored string || string will be removed");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void RemoveNegativeQuantityValuesFromEnd()
        {
            string transformed = "TEST string will be removed".Remove(-1, "TEST").From(The.End);
        }

        [TestMethod]
        public void RemoveZeroValuesFromEnd()
        {
            string transformed = "string will be removed -> TEST".Remove(0, "TEST").From(The.End);
            transformed.Should().Be("string will be removed -> TEST");

            transformed = "TEST <- again both strings will be removed -> TEST".Remove(0, "TEST").From(The.End);
            transformed.Should().Be("TEST <- again both strings will be removed -> TEST");
        }

        [TestMethod]
        public void RemoveValuesFromEnd()
        {
            string transformed = "string will be removed -> TEST".Remove(1, "TEST").From(The.End);
            transformed.Should().Be("string will be removed -> ");

            transformed = "TEST <- again both strings will be removed -> TEST".Remove(2, "TEST").From(The.End);
            transformed.Should().Be(" <- again both strings will be removed -> ");

            transformed = "string will be removed -> |TEST| some additional string".Remove(1, "TEST").From(The.End);
            transformed.Should().Be("string will be removed -> || some additional string");
        }

        [TestMethod]
        public void RemoveManyValuesFromEnd()
        {
            string transformed = "this TEST will be left, but TEST <- both strings will be removed -> TEST".Remove(2, "TEST").From(The.End);
            transformed.Should().Be("this TEST will be left, but  <- both strings will be removed -> ");

            transformed = "these will survive TEST, TEST, TEST, but these will be removed -> TEST, TEST, TEST, TEST".Remove(4, "TEST").From(The.End);
            transformed.Should().Be("these will survive TEST, TEST, TEST, but these will be removed -> , , , ");
        }

        [TestMethod]
        public void RemoveValuesCaseSensitiveFromEnd()
        {
            string transformed = "string will be removed -> TesT".Remove(1, "TesT").From(The.End);
            transformed.Should().Be("string will be removed -> ");

            transformed = "test <- this string will be left, but this will be removed -> test".Remove(1, "test").From(The.End);
            transformed.Should().Be("test <- this string will be left, but this will be removed -> ");

            transformed = "string will be removed -> |tEsT| some additional string".Remove(1, "tEsT").From(The.End);
            transformed.Should().Be("string will be removed -> || some additional string");
        }

        #endregion

        #region Remove Values Ignoring Case

        [TestMethod]
        public void RemoveValuesFromNullStringIgnoringCase()
        {
            string transformed = Const.NullString.Remove(1, "bla").IgnoringCase();
            transformed.Should().Be(Const.NullString);
        }

        [TestMethod]
        public void RemoveNullValuesIgnoringCase()
        {
            string transformed = Const.SampleString.Remove(2, null).IgnoringCase();
            transformed.Should().Be(Const.SampleString);
        }

        [TestMethod]
        public void RemoveNullValuesFromNullStringIgnoringCase()
        {
            string transformed = Const.NullString.Remove(2, null).IgnoringCase();
            transformed.Should().Be(Const.NullString);
        }

        [TestMethod]
        public void RemoveEmptyValuesIgnoringCase()
        {
            string transformed = Const.SampleString.Remove(1, String.Empty).IgnoringCase();
            transformed.Should().Be(Const.SampleString);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void RemoveNegativeQuantityValuesIgnoringCase()
        {
            string transformed = Const.SampleString.Remove(-1, "TEST").IgnoringCase();
        }

        [TestMethod]
        public void RemoveZeroValuesIgnoringCase()
        {
            string transformed = Const.SampleString.Remove(0, "TEST").IgnoringCase();
            transformed.Should().Be(Const.SampleString);
        }

        [TestMethod]
        public void RemoveOneValueIgnoringCase()
        {
            string transformed = "TEST string will be removed".Remove(1, "TeSt").IgnoringCase();
            transformed.Should().Be(" string will be removed");

            transformed = "string will be removed ->tEST".Remove(1, "tEsT").IgnoringCase();
            transformed.Should().Be("string will be removed ->");

            transformed = "string will be removed ->TEST and this will be left TEST".Remove(1, "TEST").IgnoringCase();
            transformed.Should().Be("string will be removed -> and this will be left TEST");
        }

        [TestMethod]
        public void RemoveTwoValuesIgnoringCase()
        {
            string transformed = "TesT string will be removed from both sides TEST".Remove(2, "TEST").IgnoringCase();
            transformed.Should().Be(" string will be removed from both sides ");
        }

        [TestMethod]
        public void RemoveThreeValuesIgnoringCaseFromStringWithFourValues()
        {
            string transformed = "TEST only three TeSt strings will be removed from test string TesT".Remove(3, "TesT").IgnoringCase();
            transformed.Should().Be(" only three  strings will be removed from  string TesT");
        }

        #endregion

        #region Remove Values Ignoring Case From

        [TestMethod]
        public void RemoveValuesIgnoringCaseFromBeginningOfNullString()
        {
            string transformed = Const.NullString.Remove(2, "bla").IgnoringCase().From(The.Beginning);
            transformed.Should().Be(Const.NullString);
        }

        [TestMethod]
        public void RemoveValuesIgnoringCaseFromEndOfNullString()
        {
            string transformed = Const.NullString.Remove(2, "bla").IgnoringCase().From(The.End);
            transformed.Should().Be(Const.NullString);
        }

        [TestMethod]
        public void RemoveNullValuesIgnoringCaseFromBeginning()
        {
            string transformed = Const.SampleString.Remove(1, null).IgnoringCase().From(The.Beginning);
            transformed.Should().Be(Const.SampleString);
        }

        [TestMethod]
        public void RemoveNullValuesIgnoringCaseFromEnd()
        {
            string transformed = Const.SampleString.Remove(2, null).IgnoringCase().From(The.End);
            transformed.Should().Be(Const.SampleString);
        }

        [TestMethod]
        public void RemoveNullValuesIgnoringCaseFromBeginningOfNullString()
        {
            string transformed = Const.NullString.Remove(3, null).IgnoringCase().From(The.Beginning);
            transformed.Should().Be(Const.NullString);
        }

        [TestMethod]
        public void RemoveNullValuesIgnoringCaseFromEndOfNullString()
        {
            string transformed = Const.NullString.Remove(2, null).IgnoringCase().From(The.End);
            transformed.Should().Be(Const.NullString);
        }

        [TestMethod]
        public void RemoveEmptyValuesIgnoringCaseFromBeginning()
        {
            string transformed = Const.SampleString.Remove(4, String.Empty).IgnoringCase().From(The.Beginning);
            transformed.Should().Be(Const.SampleString);
        }

        [TestMethod]
        public void RemoveEmptyValuesIgnoringCaseFromEnd()
        {
            string transformed = Const.SampleString.Remove(3, String.Empty).IgnoringCase().From(The.End);
            transformed.Should().Be(Const.SampleString);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void RemoveNegativeQuantityValuesIgnoringCaseFromBeginning()
        {
            string transformed = "TEST string will be removed".Remove(-1, "TEST").IgnoringCase().From(The.Beginning);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void RemoveNegativeQuantityValuesIgnoringCaseFromEnd()
        {
            string transformed = "TEST string will be removed".Remove(-1, "TEST").IgnoringCase().From(The.End);
        }

        [TestMethod]
        public void RemoveZeroValuesIgnoringCaseFromBeginning()
        {
            string transformed = "TEST string will be removed".Remove(0, "TEST").IgnoringCase().From(The.Beginning);
            transformed.Should().Be("TEST string will be removed");

            transformed = "TEST <- both strings will be removed -> TEST".Remove(0, "TEST").IgnoringCase().From(The.Beginning);
            transformed.Should().Be("TEST <- both strings will be removed -> TEST");
        }

        [TestMethod]
        public void RemoveZeroValuesIgnoringCaseFromEnd()
        {
            string transformed = "string will be removed -> TEST".Remove(0, "TEST").IgnoringCase().From(The.End);
            transformed.Should().Be("string will be removed -> TEST");

            transformed = "TEST <- again both strings will be removed -> TEST".Remove(0, "TEST").IgnoringCase().From(The.End);
            transformed.Should().Be("TEST <- again both strings will be removed -> TEST");
        }

        [TestMethod]
        public void RemoveOneValueIgnoringCaseFromBeginning()
        {
            string transformed = "TEST string will be removed".Remove(1, "TeSt").IgnoringCase().From(The.Beginning);
            transformed.Should().Be(" string will be removed");

            transformed = "string will be removed ->tEST".Remove(1, "tEsT").IgnoringCase().From(The.Beginning);
            transformed.Should().Be("string will be removed ->");

            transformed = "string will be removed ->TEST and this will be left TEST".Remove(1, "TEST").IgnoringCase().From(The.Beginning);
            transformed.Should().Be("string will be removed -> and this will be left TEST");
        }

        [TestMethod]
        public void RemoveTwoValuesFromBeginningIgnoringCase()
        {
            string transformed = "TesT string will be removed from both sides TEST".Remove(2, "TEST").IgnoringCase().From(The.Beginning);
            transformed.Should().Be(" string will be removed from both sides ");
        }

        [TestMethod]
        public void RemoveFiveValuesIgnoringCaseFromBeginningOfStringWithTwoValues()
        {
            string transformed = "TesT string will be removed from both sides TEST".Remove(5, "TEST").IgnoringCase().From(The.Beginning);
            transformed.Should().Be(" string will be removed from both sides ");
        }

        [TestMethod]
        public void RemoveValuesIgnoringCaseFromEnd()
        {
            string transformed = "string will be removed -> TEST".Remove(1, "tESt").IgnoringCase().From(The.End);
            transformed.Should().Be("string will be removed -> ");

            transformed = "TEST <- this string will be left, but this will be removed -> TEST".Remove(1, "test").IgnoringCase().From(The.End);
            transformed.Should().Be("TEST <- this string will be left, but this will be removed -> ");
        }

        [TestMethod]
        public void RemoveTwoValuesIgnoringCaseFromEndOfStringWithOneValue()
        {
            string transformed = "string will be removed -> |TesT| some additional string".Remove(2, "TEST").IgnoringCase().From(The.End);
            transformed.Should().Be("string will be removed -> || some additional string");
        }

        #endregion

        #region Remove All

        [TestMethod]
        public void RemoveAllTextFromNullString()
        {
            string transformed = Const.NullString.RemoveAll("bla");
            transformed.Should().Be(Const.NullString);
        }

        [TestMethod]
        public void RemoveAllNullText()
        {
            string transformed = Const.SampleString.RemoveAll(null);
            transformed.Should().Be(Const.SampleString);
        }

        [TestMethod]
        public void RemoveAllNullTextFromNullString()
        {
            string transformed = Const.NullString.RemoveAll(null);
            transformed.Should().Be(Const.NullString);
        }

        [TestMethod]
        public void RemoveAllEmptyText()
        {
            string transformed = Const.SampleString.RemoveAll(String.Empty);
            transformed.Should().Be(Const.SampleString);
        }

        [TestMethod]
        public void RemoveAllText()
        {
            string transformed = "TEST string will be removed".RemoveAll("TEST");
            transformed.Should().Be(" string will be removed");

            transformed = "TEST string will be removed from both sides TEST".RemoveAll("TEST");
            transformed.Should().Be(" string will be removed from both sides ");
        }

        [TestMethod]
        public void RemoveAllTextCaseSensitive()
        {
            string transformed = "TeSt string will be removed from both sides TeSt".RemoveAll("TeSt");
            transformed.Should().Be(" string will be removed from both sides ");

            transformed = "TEST string will NOT be removed from both sides TEST".RemoveAll("TeSt");
            transformed.Should().Be("TEST string will NOT be removed from both sides TEST");
        }

        #endregion

        #region Remove All Ignoring Case

        [TestMethod]
        public void RemoveAllTextFromNullStringIgnoringCase()
        {
            string transformed = Const.NullString.RemoveAll("bla").IgnoringCase();
            transformed.Should().Be(Const.NullString);
        }

        [TestMethod]
        public void RemoveAllNullTextIgnoringCase()
        {
            string transformed = Const.SampleString.RemoveAll(null).IgnoringCase();
            transformed.Should().Be(Const.SampleString);
        }

        [TestMethod]
        public void RemoveAllNullTextFromNullStringIgnoringCase()
        {
            string transformed = Const.NullString.RemoveAll(null).IgnoringCase();
            transformed.Should().Be(Const.NullString);
        }

        [TestMethod]
        public void RemoveAllEmptyTextIgnoringCase()
        {
            string transformed = Const.SampleString.RemoveAll(String.Empty).IgnoringCase();
            transformed.Should().Be(Const.SampleString);
        }

        [TestMethod]
        public void RemoveAllTextIgnoringCase()
        {
            string transformed = "TEST string will be removed".RemoveAll("TeSt").IgnoringCase();
            transformed.Should().Be(" string will be removed");

            transformed = "TEST string will be removed from both sides TEST".RemoveAll("tESt").IgnoringCase();
            transformed.Should().Be(" string will be removed from both sides ");

            transformed = "TEST string will be TEST removed from test the whole string TEST".RemoveAll("tESt").IgnoringCase();
            transformed.Should().Be(" string will be  removed from  the whole string ");
        }

        #endregion
    }
}
