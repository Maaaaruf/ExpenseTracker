using Autofac.Extras.Moq;
using ExpenseTracker.Framework.Entities;
using ExpenseTracker.Framework.Exceptions;
using ExpenseTracker.Framework.Repositories;
using ExpenseTracker.Framework.Services;
using ExpenseTracker.Framework.UnitOfWorks;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using System.Text;
using Xunit;

namespace ExpenseTracker.Framework.Tests.Services
{
    [ExcludeFromCodeCoverage]
    public class PaymentMethodServiceTests : IDisposable
    {
        private readonly AutoMock _mock;
        private readonly Mock<IPaymentMethodRepository> _paymentRepositoryMock;
        private readonly Mock<IExpenseUnitOfWork> _expenseUnitOfWorkMock;
        private readonly IPaymentMethodService _paymentMethodService;
        public PaymentMethodServiceTests()
        {
            _mock = AutoMock.GetLoose();
            _paymentRepositoryMock = _mock.Mock<IPaymentMethodRepository>();
            _expenseUnitOfWorkMock = _mock.Mock<IExpenseUnitOfWork>();
            _paymentMethodService = _mock.Create<PaymentMethodService>();
        }

        public void Dispose()
        {
            _paymentRepositoryMock.Reset();
            _expenseUnitOfWorkMock.Reset();
            _paymentMethodService?.Dispose();

            _mock?.Dispose();
        }

        [Fact]
        public void Create_IsPaymentMethodNull_ThrowsException()
        {
            //Arrange
            PaymentMethod payment = null;

            //Act
            Should.Throw<EntityNullException<PaymentMethod>>(() =>
                _paymentMethodService.Create(payment)
            );

            //Assert

        }

        [Fact]
        public void Create_IsDuplicateFound_ThrowsException()
        {
            //Arrange
            PaymentMethod payment = new PaymentMethod { Name = "BKash"};
            PaymentMethod existingPaymentMethod = new PaymentMethod { Name = "BKash" };

            //Act
            _expenseUnitOfWorkMock.Setup(x => x.PaymentMethodRepository)
                .Returns(_paymentRepositoryMock.Object);

            _paymentRepositoryMock.Setup(x => x.GetCount(
                It.Is<Expression<Func<PaymentMethod, bool>>>(y => y.Compile()(existingPaymentMethod))))
                .Returns(1).Verifiable();
            Should.Throw<DuplicationException>(() =>
            _paymentMethodService.Create(payment));

            //Assert
            _expenseUnitOfWorkMock.VerifyAll();
            _paymentRepositoryMock.VerifyAll();
        }

        [Fact]
        public void Create_NotNullUniquePaymentMethod_CreatePaymentMethod()
        {
            //Arrange
            PaymentMethod payment = new PaymentMethod { Name = "BKash" };

            _expenseUnitOfWorkMock.Setup(x => x.PaymentMethodRepository)
                 .Returns(_paymentRepositoryMock.Object);

            _paymentRepositoryMock.Setup(x => x.GetCount(
                It.Is<Expression<Func<PaymentMethod, bool>>>(y => y.Compile()(payment))))
                .Returns(0).Verifiable();

            _paymentRepositoryMock.Setup(x => x.Add(It.Is<PaymentMethod>(y => y.Name == payment.Name))).Verifiable();
            _expenseUnitOfWorkMock.Setup(x => x.Save()).Verifiable();


            //Act
            _paymentMethodService.Create(payment);

            //Assert
            _paymentRepositoryMock.VerifyAll();
            _expenseUnitOfWorkMock.VerifyAll();
        }


        [Fact]
        public void Update_IsPaymentMethodNull_ThrowsException()
        {
            //Arrange
            PaymentMethod payment = null;

            //Act
            Should.Throw<EntityNullException<PaymentMethod>>(() =>
                _paymentMethodService.Update(payment)
            );

            //Assert

        }

        [Fact]
        public void Update_IsDuplicateFound_ThrowsException()
        {
            //Arrange
            PaymentMethod payment = new PaymentMethod { Name = "BKash" };
            PaymentMethod existingPaymentMethod = new PaymentMethod { Name = "BKash" };

            //Act
            _expenseUnitOfWorkMock.Setup(x => x.PaymentMethodRepository)
                .Returns(_paymentRepositoryMock.Object);

            _paymentRepositoryMock.Setup(x => x.GetCount(
                It.Is<Expression<Func<PaymentMethod, bool>>>(y => y.Compile()(existingPaymentMethod))))
                .Returns(1).Verifiable();
            Should.Throw<DuplicationException>(() =>
            _paymentMethodService.Update(payment));

            //Assert
            _expenseUnitOfWorkMock.VerifyAll();
            _paymentRepositoryMock.VerifyAll();
        }

    }
}
