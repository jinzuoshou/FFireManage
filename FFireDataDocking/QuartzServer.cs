using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using Common.Logging;
using Common.Logging.Configuration;
using Quartz;
using Quartz.Impl;

namespace FFireDataDocking
{
    /// <summary>
    /// The main server logic.
    /// </summary>
    public class QuartzServer : IQuartzServer
    {
        private readonly ILog logger;
        private ISchedulerFactory schedulerFactory;
        private IScheduler scheduler;

        /// <summary>
        /// Initializes a new instance of the <see cref="QuartzServer"/> class.
        /// </summary>
        public QuartzServer()
        {
            logger = LogManager.GetLogger(GetType());
        }

        /// <summary>
        /// Initializes the instance of the <see cref="QuartzServer"/> class.
        /// </summary>
        public virtual void Initialize()
        {
            try
            {
                if (scheduler != null)
                {
                    return ;
                }
                var properties = new NameValueCollection();
                properties["quartz.scheduler.instanceName"] = ConfigurationManager.AppSettings["quartz.scheduler.instanceName"];

                // 设置线程池
                properties["quartz.threadPool.type"] = "Quartz.Simpl.SimpleThreadPool, Quartz";
                properties["quartz.threadPool.threadCount"] = "10";
                properties["quartz.threadPool.threadPriority"] = "2";

                schedulerFactory = CreateSchedulerFactory(properties);
                scheduler = GetScheduler();

                ////---------------------------------------代码添加job和trigger
                //// computer a time that is on the next round minute
                //DateTimeOffset runTime = DateBuilder.EvenMinuteDate(DateTimeOffset.UtcNow);

                //logger.Info("------- Scheduling Job  -------------------");

                //// define the job and tie it to our HelloJob class
                //IJobDetail job = new JobDetailImpl("SynDataJob", "SynDataJobGroup", typeof(SynDataJob), true, false);
                //foreach (var item in collection)
                //{
                //    ICronTrigger trigger = new CronTriggerImpl("",);

                //    // Tell quartz to schedule the job using our trigger
                //    scheduler.ScheduleJob(job, trigger);
                //    logger.Info(string.Format("{0} will run at: {1}", job.Key, runTime.ToString("r"))); 
                //}
            }
            catch (Exception e)
            {
                logger.Error("Server initialization failed:" + e.Message, e);
                throw;
            }
        }

        /// <summary>
        /// Gets the scheduler with which this server should operate with.
        /// </summary>
        /// <returns></returns>
        protected virtual IScheduler GetScheduler()
        {
            return schedulerFactory.GetScheduler();
        }

        /// <summary>
        /// Returns the current scheduler instance (usually created in <see cref="Initialize" />
        /// using the <see cref="GetScheduler" /> method).
        /// </summary>
        public virtual IScheduler Scheduler
        {
            get { return scheduler; }
        }

        /// <summary>
        /// Creates the scheduler factory that will be the factory
        /// for all schedulers on this instance.
        /// </summary>
        /// <returns></returns>
        protected virtual ISchedulerFactory CreateSchedulerFactory(NameValueCollection p)
        {
            return new StdSchedulerFactory();
        }

        /// <summary>
        /// Starts this instance, delegates to scheduler.
        /// </summary>
        public virtual void Start()
        {
            scheduler.Start();

            try
            {
                Thread.Sleep(3000);
            }
            catch (ThreadInterruptedException)
            {
            }

            logger.Info("Scheduler started successfully");
        }

        /// <summary>
        /// Stops this instance, delegates to scheduler.
        /// </summary>
        public virtual void Stop()
        {
            scheduler.Shutdown(true);
            logger.Info("Scheduler shutdown complete");
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public virtual void Dispose()
        {
            // no-op for now
        }

        /// <summary>
        /// Pauses all activity in scheudler.
        /// </summary>
        public virtual void Pause()
        {
            scheduler.PauseAll();
        }

        /// <summary>
        /// Resumes all acitivity in server.
        /// </summary>
        public void Resume()
        {
            scheduler.ResumeAll();
        }
    }
}
