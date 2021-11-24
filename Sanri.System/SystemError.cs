using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Sanri.System
{
    public class SystemError
    {
        public const string UserIsNotFoundMessage = "Пользователь не найден";
        public const string InvalidPhoneNumberFormatMessage = "Неверный формат номера телефона";
        public const string FillFieldMessageMessage = "Заполните поле";
        public const string EnterPasswordMessage = "Введите пароль";
        public const string EnterPasswordConfirmationMessage = "Введите подтверждение пароля";
        public const string EnterNewPasswordMessage = "Введите новый пароль";
        public const string PasswordsDoesNotMatchMessage = "Пароли не совпадают";
        public const string WrongPhoneNumberFormatMessage = "Неверный формат номера телефона";
        public const string UserProfileWrongEmailFormatMessage = "Неверный формат электронной почты";
        public const string EnterCodeConfirmationMessage = "Введите код подтверждения";
        public const string SumMustBeGreaterThanZeroMessage = "Введите сумму больше нуля";
        public const string NotEnoughMoneyMessage = "Недостаточно средств на балансе";
        public const string InvalidAccountNumberMessage = "Неправильный реквизит услуги";
        public const string PasswordRecoveryRequestIsNotFoundMessage = "Заявка на смену пароля не найдена";
        public const string WrongConfirmationCodeMessage = "Неверный код подтверждения";
        public const string SumIsTooSmallMessage = "Слишком маленькая сумма";
        public const string SumIsTooBigMessage = "Сумма слишком велика";
        public const string BadSumMessage = "Некорректная сумма платежа";
        public const string SelectSalepointMessage = "Выберите кассу";
        public const string SumMustBeOneKztAtLeastMessage = "Минимальный платеж - 1 тенге";
        public const string AccountIsNotFoundMessage = "Номер счета не найден";
        public const string InvalidPasswordMessage = "Неверный пароль";
        public const string WithdrawalAlreadyRefundedMessage = "Заявка на вывод уже возвращена";

        public const string UserIsBlockedMessage = "Пользователь заблокирован";
        public const string UserIsNotVerifiedMessage = "Пользователь не верифицирован";
        public const string OperationIsForbiddenMessage = "Данная операция недоступна";
        public const string EnterLoginOfOtherUserMessage = "Укажите номер кошелька другого пользователя";
        
        public static readonly SystemError UserIsNotFound = new(UserIsNotFoundMessage);
        public static readonly SystemError UsernameIsAlreadyTaken = new("This username is already taken");
        public static readonly SystemError WrongConfirmationCode = new(WrongConfirmationCodeMessage);
        public static readonly SystemError CannotUpdateProfileUserIsAlreadyVerified = new("Невозможно изменить профиль, пользователь уже верифицирован");
        public static readonly SystemError CannotPartiallyUpdateProfileUserIsNotVerified = new("Невозможно изменить профиль, пользователь не верифицирован");
        public static readonly SystemError CannotUpdateProfileUserProfile = new("Невозможно изменить профиль");

        public static readonly SystemError PasswordRecoveryRequestIsExpired = new("Время заявки на восстановление пароля истекло, создайте новую заявку");

        public static readonly SystemError UserRegistrationRequestIsExpired = new("Срок заявки на регистрацию истек, создайте новую заявку");
        public static readonly SystemError UserRegistrationIsDenied = new("Отказано в регистрации");
        public static readonly SystemError UserVerificationRequestIsNotFound = new("Не найдено запроса на верификацию");
        public static readonly SystemError UserVerificationRequestIsUsed = new("Запрос на верификацию уже использован");

        public static readonly SystemError UserIsBlocked = new(UserIsBlockedMessage);
        public static readonly SystemError OperationIsAvailableForVerifiedUsers = new("Данная операция доступна только для верифицированных пользователей");
        public static readonly SystemError OperationIsForbidden = new(OperationIsForbiddenMessage);

        public static readonly SystemError NotEnoughMoney = new("Недостаточно средств на балансе");

        public static readonly SystemError UserNotificationIsNotFound = new("Пользовательское соглашение не найдено");
        public static readonly SystemError UserNotificationIsAlreadyAccepted = new("Пользовательское соглашение уже принято");

        public static readonly SystemError NewsItemIsNotFound = new("Новость не найдена");
        
        public static readonly SystemError InternalSystemError = new("Внутренняя ошибка системы");

        //withdrawal errors
        public static readonly SystemError PaymentDenied = new("Прием платежа запрещен, обратитесь к оператору");
        public static readonly SystemError ProviderDailyLimitExceeded = new("Превышен суточный лимит на сумму операций");
        public static readonly SystemError AccountIsInactive = new("Счет абонента не активен");
        
        public string? Message { get; set; }

        public IDictionary<string, string>? ParameterErrors { get; set; }

        [JsonConstructor]
        public SystemError()
        {
        }

        private SystemError(string message)
        {
            Message = message;
        }

        public SystemError(string parameterName, string message)
        {
            ParameterErrors = new Dictionary<string, string>
            {
                [parameterName] = message
            };
        }

        public SystemError(string? message,
                           IDictionary<string, string> parameterErrors)
        {
            Message         = message;
            ParameterErrors = parameterErrors;
        }

        public SystemError SetError(string parameterName, string errorMessage)
        {
            ParameterErrors ??= new Dictionary<string, string>();

            ParameterErrors[parameterName] = errorMessage;

            return this;
        }

        public static SystemError YouSendSMSTooOften(TimeSpan tryIn)
        {
            var strTryIn = tryIn.ToString(@"mm\:ss");

            return new SystemError($"Вы слишком часто отправляете СМС, попробуйте через {strTryIn}");
        }

        public static string PasswordMinimumLengthGuardMessage(long passwordMinLength)
        {
            return $"Пароль должен быть не менее {passwordMinLength} символов";
        }

        public static SystemError YouCanChangeVerificationMethodIn(TimeSpan tryIn)
        {
            var strTryIn = tryIn.ToString(@"mm\:ss");

            return new SystemError($"Смена способа верификации будет доступна через {strTryIn}");
        }

        public static SystemError DailyLimitExceeded(decimal remainder)
        {
            return new SystemError($"Доступная сумма для снятия {remainder:F2} тенге");
        }

        public static SystemError SumMultiplicityError(string parameterName, IList<decimal> availableSums)
        {
            var message = availableSums.Count == 1
                ? $"Укажите кратную сумму (например: {availableSums[0]})"
                : $"Укажите кратную сумму (например: {availableSums[0]} или {availableSums[1]})";

            return new SystemError(parameterName, message);
        }
    }
}