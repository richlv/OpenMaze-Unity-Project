﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using contingency;
using data;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

// ReSharper disable once CheckNamespace Tests need to be in Tests namespace
namespace Tests
{
    public class ContingencyValidatorTest
    {
        private ContingencyBehaviourValidator _contingencyBehaviourValidator;
        
        [SetUp]
        public void SetupContingencyValidator()
        {
            // Use activator to bypass private constructor.
            _contingencyBehaviourValidator = 
                (ContingencyBehaviourValidator) Activator.CreateInstance(typeof(ContingencyBehaviourValidator), true);   
        }
        
        [Test]
        public void ContingencyValidator_OneConditionTrue_isTrue()
        {
            var contingencyBehaviour = new Data.ContingencyBehaviour{RestartBlock = true};
            
            Assert.IsTrue(_contingencyBehaviourValidator.ValidateContingencyBehaviour(contingencyBehaviour));
        }
        
        [Test]
        public void ContingencyValidator_ArrayNonNull_IsTrue()
        {
            var contingencyBehaviour = new Data.ContingencyBehaviour
            {
                NextTrials = new List<int>{1, 2}
            };
            
            Assert.IsTrue(_contingencyBehaviourValidator.ValidateContingencyBehaviour(contingencyBehaviour));
        }
        
        [Test]
        public void ContingencyValidator_MultipleConditionTrue_IsFalse()
        {
            var contingencyBehaviour = new Data.ContingencyBehaviour{RestartBlock = true, RepeatContingency = true};
            
            Assert.IsFalse(_contingencyBehaviourValidator.ValidateContingencyBehaviour(contingencyBehaviour));
        }
        
        [Test]
        public void ContingencyValidator_OneConditionTrue_ArrayNonNull_IsFalse()
        {
            var contingencyBehaviour = new Data.ContingencyBehaviour
            {
                NextTrials = new List<int>{1, 2}, RestartBlock = true
            };
            
            Assert.IsFalse(_contingencyBehaviourValidator.ValidateContingencyBehaviour(contingencyBehaviour));
        }

    }
}