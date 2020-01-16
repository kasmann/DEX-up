using System;

namespace Unit21JobExecutor
{
    public interface IJobExecutor
    {
        /// Кол-во задач в очереди на обработку
        int Amount { get; }
        /// <summary>
        /// Запустить обработку очереди (выполнение добавленных в очередь задач) и установить максимальное кол-во параллельных задач
        /// </summary>
        /// <param name="maxConcurrent">максимальное кол-во одновременно выполняемых задач</param>
        void Start(int maxConcurrent);
        /// <summary>
        /// Остановить обработку очереди и выполнение задач
        /// </summary>
        void Stop();
        /// <summary>
        /// Добавить задачу в очередь
        /// </summary>
        /// <param name="action"></param>
        void Add(Action action);
        /// <summary>
        /// Очистить очередь задач
        /// </summary>
        void Clear();
    }
}