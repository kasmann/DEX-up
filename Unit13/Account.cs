namespace Unit13
{
    class Account
    {
        // Объявляем делегат
        public delegate void AccountStateHandler(string message);
        
        // Создаем переменную делегата
        private AccountStateHandler _del;
 
        // Регистрируем делегат
        public void RegisterHandler(AccountStateHandler del)
        {
            _del += del; // добавляем делегат
        }
        
        // Отмена регистрации делегата
        public void UnregisterHandler(AccountStateHandler del)
        {
            _del -= del; // удаляем делегат
        }

        private int _sum; // Переменная для хранения суммы
 
        public Account(int sum)
        {
            _sum = sum;
        }
 
        public int CurrentSum => _sum;

        public void Put(int sum)
        {
            _sum += sum;
        }
 
        public void Withdraw(int sum)
        {
            if (sum <= _sum)
            {
                _sum -= sum;
                _del?.Invoke($"Сумма {sum} снята со счета");
            }
            else
            {
                _del?.Invoke("Недостаточно денег на счете");
            }
        }
    }
}