﻿using Desafio.Stefanini.Application.Common.Behaviours;
using Desafio.Stefanini.Application.Common.Interfaces;
using Desafio.Stefanini.Application.Pedidos.Commands.CreatePedido;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;

namespace Desafio.Stefanini.Application.UnitTests.Common.Behaviours;

public class RequestLoggerTests
{
    private Mock<ILogger<CreatePedidoCommand>> _logger = null!;
    private Mock<IUser> _user = null!;
    private Mock<IIdentityService> _identityService = null!;

    [SetUp]
    public void Setup()
    {
        _logger = new Mock<ILogger<CreatePedidoCommand>>();
        _user = new Mock<IUser>();
        _identityService = new Mock<IIdentityService>();
    }

    [Test]
    public async Task ShouldCallGetUserNameAsyncOnceIfAuthenticated()
    {
        _user.Setup(x => x.Id).Returns(Guid.NewGuid().ToString());

        var requestLogger = new LoggingBehaviour<CreatePedidoCommand>(_logger.Object, _user.Object, _identityService.Object);

        await requestLogger.Process(new CreatePedidoCommand { Pago = true, NomeCliente = "Fábio" }, new CancellationToken());

        _identityService.Verify(i => i.GetUserNameAsync(It.IsAny<string>()), Times.Once);
    }

    [Test]
    public async Task ShouldNotCallGetUserNameAsyncOnceIfUnauthenticated()
    {
        var requestLogger = new LoggingBehaviour<CreatePedidoCommand>(_logger.Object, _user.Object, _identityService.Object);

        await requestLogger.Process(new CreatePedidoCommand { Pago = true, NomeCliente = "Fábio" }, new CancellationToken());

        _identityService.Verify(i => i.GetUserNameAsync(It.IsAny<string>()), Times.Never);
    }
}
