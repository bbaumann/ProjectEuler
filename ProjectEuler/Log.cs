using System;
using log4net;

// Cherche la configuration du logger dans le fichier de configuration
// De l'assemblée principale courante (web.config ou app.config)
[assembly: log4net.Config.XmlConfigurator()]
namespace ProjectEuler
    {
        /// <summary>
        /// <para>
        /// Cette classe permet de mettre dans une journal tous les évenènements
        /// choisis par le développeur
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// Elle écrit sur les supports (appenders) configurés dans le fichier de configuration
        /// de l'application en cours (<c>web.config</c> ou <c>&lt;app&gt;.config</c>).
        /// </para>
        /// <para>
        /// Parmi les différents supports
        /// <list type="table">
        ///		<item>
        ///			<term>RollingLogFileAppender</term>
        ///			<description>Fichier tournant, on peut lui indiquer le nombre de cycles ainsi que la taille maximum</description>
        ///		</item>
        ///		<item>
        ///			<term>EventLogAppender</term>
        ///			<description>Journaux standard de Windows</description>
        ///		</item>
        /// </list>
        /// </para>
        /// <para>
        /// Pour plus d'informations, rendez vous sur l'adresse <c>http://logging.apache.org</c>
        /// </para>
        /// </remarks>
        /// <example>
        /// Dans le fichier de configuration ajoutez la déclaration de section
        /// <code>
        /// &lt;configSections&gt;
        ///   &lt;section name="log4net" type="System.Configuration.IgnoreSectionHandler" /&gt;
        /// &lt;/configSections&gt;
        /// </code>
        /// Puis le contenu de la section elle même	
        /// <code>
        /// &lt;log4net&gt;
        /// &lt;appender name="RollingLogFileAppender" type="log4net.Appender.RollingFileAppender"&gt;
        ///		&lt;!--
        ///		&lt;filter type="log4net.Filter.LevelRangeFilter"&gt;
        ///		&lt;levelMin value="INFO" /&gt;
        ///		&lt;levelMax value="FATAL" /&gt;
        ///		&lt;/filter&gt;
        ///		--&gt;
        ///		&lt;param name="File" value="<b>logfilename.log</b>" /&gt;
        ///		&lt;param name="AppendToFile" value="true" /&gt;
        ///		&lt;param name="MaxSizeRollBackups" value="10" /&gt;
        ///		&lt;param name="MaximumFileSize" value="10000" /&gt;
        ///		&lt;param name="RollingStyle" value="Size" /&gt;
        ///		&lt;param name="StaticLogFileName" value="true" /&gt;
        ///		&lt;layout type="log4net.Layout.PatternLayout"&gt;
        ///			&lt;!-- &lt;param name="Header" value="[Eurosport Log File (Time|ThreadName|Level|Message)]\r\n" /&gt; --&gt;
        ///			&lt;!-- &lt;param name="Footer" value="[Footer]\r\n" /&gt; --&gt;
        ///			&lt;!-- http://logging.apache.org/log4j/docs/api/org/apache/log4j/PatternLayout.html --&gt;
        ///			&lt;!-- removed : %C [%x] --&gt;
        ///			&lt;param name="ConversionPattern" value="%d [%t] %-5p - %m%n" /&gt;
        ///		&lt;/layout&gt;
        /// &lt;/appender&gt;
        /// &lt;appender name="EventLogAppender" type="log4net.Appender.EventLogAppender" &gt;
        ///		&lt;layout type="log4net.Layout.PatternLayout"&gt;
        ///			&lt;conversionPattern value="%d [%t] %-5p - %m%n" /&gt;
        ///		&lt;/layout&gt;
        /// &lt;/appender&gt;
        /// &lt;logger name="com.eurosport.logging.Log"&gt;
        ///		<b>&lt;level value="ALL" /&gt;</b>
        ///		&lt;appender-ref ref="RollingLogFileAppender" /&gt;
        ///		&lt;appender-ref ref="EventLogAppender" /&gt;
        /// &lt;/logger&gt;
        /// &lt;/log4net&gt;
        /// </code>
        /// </example>
        public class Log
        {
            private static log4net.ILog log;

            static Log()
            {
                log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            }

            #region Debug LEVEL
            /// <summary>
            /// Ecrit un message de niveau DEBUG dans les journaux
            /// </summary>
            /// <param name="message">Objet message à loguer</param>
            public static void Debug(object message)
            {
                log.Debug(message);
            }

            /// <summary>
            /// Ecrit un message de niveau DEBUG dans les journaux
            /// </summary>
            /// <param name="message">String message à loguer</param>
            public static void Debug(string message)
            {
                log.Debug(message);
            }

            /// <summary>
            /// Ecrit un message de niveau DEBUG dans les journaux
            /// </summary>
            /// <param name="message">Objet message à loguer</param>
            /// <param name="t">L'exception à loguer, incluant la pile des appels</param>
            public static void Debug(object message, Exception t)
            {
                log.Debug(message, t);
            }

            /// <summary>
            /// Ecrit un message de niveau DEBUG dans les journaux
            /// </summary>
            /// <param name="message">String message à loguer</param>
            /// <param name="t">L'exception à loguer, incluant la pile des appels</param>
            public static void Debug(string message, Exception t)
            {
                log.Debug(message, t);
            }

            /// <summary>
            /// Ecrit un message de niveau DEBUG dans les journaux
            /// </summary>
            /// <param name="format">Chaîne de format composite.</param>
            /// <param name="args">
            /// Tableau <see cref="Object"/> contenant zéro ou plusieurs objets à mettre en forme.
            /// </param>
            public static void Debug(string format, params object[] args)
            {
                log.DebugFormat(format, args);
            }

            /// <summary>
            /// Ecrit un message de niveau DEBUG dans les journaux
            /// </summary>
            /// <param name="format">Chaîne de format composite.</param>
            /// <param name="t">L'exception à loguer, incluant la pile des appels</param>
            /// <param name="args">
            /// Tableau <see cref="Object"/> contenant zéro ou plusieurs objets à mettre en forme.
            /// </param>
            public static void Debug(string format, Exception t, params object[] args)
            {
                if (args == null) { Debug(format, t); }
                else { Debug(String.Format(format, args), t); }
            }

            /// <summary>
            /// Ecrit un message de niveau DEBUG dans les journaux
            /// </summary>
            /// <param name="provider">
            /// <see cref="IFormatProvider"/> qui fournit des informations de format propres à la culture.
            /// </param>
            /// <param name="format">Chaîne de format composite.</param>
            /// <param name="args">
            /// Tableau <see cref="Object"/> contenant zéro ou plusieurs objets à mettre en forme.
            /// </param>
            public static void Debug(IFormatProvider provider, string format, params object[] args)
            {
                log.DebugFormat(provider, format, args);
            }

            /// <summary>
            /// Ecrit un message de niveau DEBUG dans les journaux
            /// </summary>
            /// <param name="provider">
            /// <see cref="IFormatProvider"/> qui fournit des informations de format propres à la culture.
            /// </param>
            /// <param name="format">Chaîne de format composite.</param>
            /// <param name="t">L'exception à loguer, incluant la pile des appels</param>
            /// <param name="args">
            /// Tableau <see cref="Object"/> contenant zéro ou plusieurs objets à mettre en forme.
            /// </param>
            public static void Debug(IFormatProvider provider, string format, Exception t, params object[] args)
            {
                if (provider == null) { Debug(format, t, args); }
                else { Debug(String.Format(provider, format, args), t); }
            }
            #endregion

            #region Info LEVEL
            /// <summary>
            /// Ecrit un message de niveau INFO dans les journaux
            /// </summary>
            /// <param name="message">Objet message à loguer</param>
            public static void Info(object message)
            {
                log.Info(message);
            }

            /// <summary>
            /// Ecrit un message de niveau INFO dans les journaux
            /// </summary>
            /// <param name="message">String message à loguer</param>
            public static void Info(string message)
            {
                log.Info(message);
            }

            /// <summary>
            /// Ecrit un message de niveau INFO dans les journaux
            /// </summary>
            /// <param name="message">Objet message à loguer</param>
            /// <param name="t">L'exception à loguer, incluant la pile des appels</param>
            public static void Info(object message, Exception t)
            {
                log.Info(message, t);
            }

            /// <summary>
            /// Ecrit un message de niveau INFO dans les journaux
            /// </summary>
            /// <param name="message">String message à loguer</param>
            /// <param name="t">L'exception à loguer, incluant la pile des appels</param>
            public static void Info(string message, Exception t)
            {
                log.Info(message, t);
            }

            /// <summary>
            /// Ecrit un message de niveau INFO dans les journaux
            /// </summary>
            /// <param name="format">Chaîne de format composite.</param>
            /// <param name="args">
            /// Tableau <see cref="Object"/> contenant zéro ou plusieurs objets à mettre en forme.
            /// </param>
            public static void Info(string format, params object[] args)
            {
                log.InfoFormat(format, args);
            }

            /// <summary>
            /// Ecrit un message de niveau INFO dans les journaux
            /// </summary>
            /// <param name="format">Chaîne de format composite.</param>
            /// <param name="t">L'exception à loguer, incluant la pile des appels</param>
            /// <param name="args">
            /// Tableau <see cref="Object"/> contenant zéro ou plusieurs objets à mettre en forme.
            /// </param>
            public static void Info(string format, Exception t, params object[] args)
            {
                if (args == null) { Info(format, t); }
                else { Info(String.Format(format, args), t); }
            }

            /// <summary>
            /// Ecrit un message de niveau INFO dans les journaux
            /// </summary>
            /// <param name="provider">
            /// <see cref="IFormatProvider"/> qui fournit des informations de format propres à la culture.
            /// </param>
            /// <param name="format">Chaîne de format composite.</param>
            /// <param name="args">
            /// Tableau <see cref="Object"/> contenant zéro ou plusieurs objets à mettre en forme.
            /// </param>
            public static void Info(IFormatProvider provider, string format, params object[] args)
            {
                log.InfoFormat(provider, format, args);
            }

            /// <summary>
            /// Ecrit un message de niveau INFO dans les journaux
            /// </summary>
            /// <param name="provider">
            /// <see cref="IFormatProvider"/> qui fournit des informations de format propres à la culture.
            /// </param>
            /// <param name="format">Chaîne de format composite.</param>
            /// <param name="t">L'exception à loguer, incluant la pile des appels</param>
            /// <param name="args">
            /// Tableau <see cref="Object"/> contenant zéro ou plusieurs objets à mettre en forme.
            /// </param>
            public static void Info(IFormatProvider provider, string format, Exception t, params object[] args)
            {
                if (provider == null) { Info(format, t, args); }
                else { Info(String.Format(provider, format, args), t); }
            }
            #endregion

            #region Warn LEVEL
            /// <summary>
            /// Ecrit un message de niveau WARNing dans les journaux
            /// </summary>
            /// <param name="message">Objet message à loguer</param>
            public static void Warn(object message)
            {
                log.Warn(message);
            }

            /// <summary>
            /// Ecrit un message de niveau WARNing dans les journaux
            /// </summary>
            /// <param name="message">String message à loguer</param>
            public static void Warn(string message)
            {
                log.Warn(message);
            }

            /// <summary>
            /// Ecrit un message de niveau WARN dans les journaux
            /// </summary>
            /// <param name="message">Objet message à loguer</param>
            /// <param name="t">L'exception à loguer, incluant la pile des appels</param>
            public static void Warn(object message, Exception t)
            {
                log.Warn(message, t);
            }

            /// <summary>
            /// Ecrit un message de niveau WARN dans les journaux
            /// </summary>
            /// <param name="message">String message à loguer</param>
            /// <param name="t">L'exception à loguer, incluant la pile des appels</param>
            public static void Warn(string message, Exception t)
            {
                log.Warn(message, t);
            }

            /// <summary>
            /// Ecrit un message de niveau WARNing dans les journaux
            /// </summary>
            /// <param name="format">Chaîne de format composite.</param>
            /// <param name="args">
            /// Tableau <see cref="Object"/> contenant zéro ou plusieurs objets à mettre en forme.
            /// </param>
            public static void Warn(string format, params object[] args)
            {
                log.WarnFormat(format, args);
            }

            /// <summary>
            /// Ecrit un message de niveau WARN dans les journaux
            /// </summary>
            /// <param name="format">Chaîne de format composite.</param>
            /// <param name="t">L'exception à loguer, incluant la pile des appels</param>
            /// <param name="args">
            /// Tableau <see cref="Object"/> contenant zéro ou plusieurs objets à mettre en forme.
            /// </param>
            public static void Warn(string format, Exception t, params object[] args)
            {
                if (args == null) { Warn(format, t); }
                else { Warn(String.Format(format, args), t); }
            }

            /// <summary>
            /// Ecrit un message de niveau WARNing dans les journaux
            /// </summary>
            /// <param name="provider">
            /// <see cref="IFormatProvider"/> qui fournit des informations de format propres à la culture.
            /// </param>
            /// <param name="format">Chaîne de format composite.</param>
            /// <param name="args">
            /// Tableau <see cref="Object"/> contenant zéro ou plusieurs objets à mettre en forme.
            /// </param>
            public static void Warn(IFormatProvider provider, string format, params object[] args)
            {
                log.WarnFormat(provider, format, args);
            }

            /// <summary>
            /// Ecrit un message de niveau WARN dans les journaux
            /// </summary>
            /// <param name="provider">
            /// <see cref="IFormatProvider"/> qui fournit des informations de format propres à la culture.
            /// </param>
            /// <param name="format">Chaîne de format composite.</param>
            /// <param name="t">L'exception à loguer, incluant la pile des appels</param>
            /// <param name="args">
            /// Tableau <see cref="Object"/> contenant zéro ou plusieurs objets à mettre en forme.
            /// </param>
            public static void Warn(IFormatProvider provider, string format, Exception t, params object[] args)
            {
                if (provider == null) { Warn(format, t, args); }
                else { Warn(String.Format(provider, format, args), t); }
            }
            #endregion

            #region Error LEVEL
            /// <summary>
            /// Ecrit un message de niveau ERROR dans les journaux
            /// </summary>
            /// <param name="message">Objet message à loguer</param>
            public static void Error(object message)
            {
                log.Error(message);
            }

            /// <summary>
            /// Ecrit un message de niveau ERROR dans les journaux
            /// </summary>
            /// <param name="message">String message à loguer</param>
            public static void Error(string message)
            {
                log.Error(message);
            }

            /// <summary>
            /// Ecrit un message de niveau ERROR dans les journaux
            /// </summary>
            /// <param name="message">Objet message à loguer</param>
            /// <param name="t">L'exception à loguer, incluant la pile des appels</param>
            public static void Error(object message, Exception t)
            {
                log.Error(message, t);
            }

            /// <summary>
            /// Ecrit un message de niveau ERROR dans les journaux
            /// </summary>
            /// <param name="message">String message à loguer</param>
            /// <param name="t">L'exception à loguer, incluant la pile des appels</param>
            public static void Error(string message, Exception t)
            {
                log.Error(message, t);
            }

            /// <summary>
            /// Ecrit un message de niveau ERROR dans les journaux
            /// </summary>
            /// <param name="format">Chaîne de format composite.</param>
            /// <param name="args">
            /// Tableau <see cref="Object"/> contenant zéro ou plusieurs objets à mettre en forme.
            /// </param>
            public static void Error(string format, params object[] args)
            {
                log.ErrorFormat(format, args);
            }

            /// <summary>
            /// Ecrit un message de niveau ERROR dans les journaux
            /// </summary>
            /// <param name="format">Chaîne de format composite.</param>
            /// <param name="t">L'exception à loguer, incluant la pile des appels</param>
            /// <param name="args">
            /// Tableau <see cref="Object"/> contenant zéro ou plusieurs objets à mettre en forme.
            /// </param>
            public static void Error(string format, Exception t, params object[] args)
            {
                if (args == null) { Error(format, t); }
                else { Error(String.Format(format, args), t); }
            }

            /// <summary>
            /// Ecrit un message de niveau ERROR dans les journaux
            /// </summary>
            /// <param name="provider">
            /// <see cref="IFormatProvider"/> qui fournit des informations de format propres à la culture.
            /// </param>
            /// <param name="format">Chaîne de format composite.</param>
            /// <param name="args">
            /// Tableau <see cref="Object"/> contenant zéro ou plusieurs objets à mettre en forme.
            /// </param>
            public static void Error(IFormatProvider provider, string format, params object[] args)
            {
                log.ErrorFormat(provider, format, args);
            }

            /// <summary>
            /// Ecrit un message de niveau ERROR dans les journaux
            /// </summary>
            /// <param name="provider">
            /// <see cref="IFormatProvider"/> qui fournit des informations de format propres à la culture.
            /// </param>
            /// <param name="format">Chaîne de format composite.</param>
            /// <param name="t">L'exception à loguer, incluant la pile des appels</param>
            /// <param name="args">
            /// Tableau <see cref="Object"/> contenant zéro ou plusieurs objets à mettre en forme.
            /// </param>
            public static void Error(IFormatProvider provider, string format, Exception t, params object[] args)
            {
                if (provider == null) { Error(format, t, args); }
                else { Error(String.Format(provider, format, args), t); }
            }
            #endregion

            #region Fatal LEVEL
            /// <summary>
            /// Ecrit un message de niveau FATAL dans les journaux
            /// </summary>
            /// <param name="message">Objet message à loguer</param>
            public static void Fatal(object message)
            {
                log.Fatal(message);
            }

            /// <summary>
            /// Ecrit un message de niveau FATAL dans les journaux
            /// </summary>
            /// <param name="message">String message à loguer</param>
            public static void Fatal(string message)
            {
                log.Fatal(message);
            }

            /// <summary>
            /// Ecrit un message de niveau FATAL dans les journaux
            /// </summary>
            /// <param name="message">Objet message à loguer</param>
            /// <param name="t">L'exception à loguer, incluant la pile des appels</param>
            public static void Fatal(object message, Exception t)
            {
                log.Fatal(message, t);
            }

            /// <summary>
            /// Ecrit un message de niveau FATAL dans les journaux
            /// </summary>
            /// <param name="message">String message à loguer</param>
            /// <param name="t">L'exception à loguer, incluant la pile des appels</param>
            public static void Fatal(string message, Exception t)
            {
                log.Fatal(message, t);
            }

            /// <summary>
            /// Ecrit un message de niveau FATAL dans les journaux
            /// </summary>
            /// <param name="format">Chaîne de format composite.</param>
            /// <param name="args">
            /// Tableau <see cref="Object"/> contenant zéro ou plusieurs objets à mettre en forme.
            /// </param>
            public static void Fatal(string format, params object[] args)
            {
                log.FatalFormat(format, args);
            }

            /// <summary>
            /// Ecrit un message de niveau FATAL dans les journaux
            /// </summary>
            /// <param name="format">Chaîne de format composite.</param>
            /// <param name="t">L'exception à loguer, incluant la pile des appels</param>
            /// <param name="args">
            /// Tableau <see cref="Object"/> contenant zéro ou plusieurs objets à mettre en forme.
            /// </param>
            public static void Fatal(string format, Exception t, params object[] args)
            {
                if (args == null) { Fatal(format, t); }
                else { Fatal(String.Format(format, args), t); }
            }

            /// <summary>
            /// Ecrit un message de niveau FATAL dans les journaux
            /// </summary>
            /// <param name="provider">
            /// <see cref="IFormatProvider"/> qui fournit des informations de format propres à la culture.
            /// </param>
            /// <param name="format">Chaîne de format composite.</param>
            /// <param name="args">
            /// Tableau <see cref="Object"/> contenant zéro ou plusieurs objets à mettre en forme.
            /// </param>
            public static void Fatal(IFormatProvider provider, string format, params object[] args)
            {
                log.FatalFormat(provider, format, args);
            }

            /// <summary>
            /// Ecrit un message de niveau FATAL dans les journaux
            /// </summary>
            /// <param name="provider">
            /// <see cref="IFormatProvider"/> qui fournit des informations de format propres à la culture.
            /// </param>
            /// <param name="format">Chaîne de format composite.</param>
            /// <param name="t">L'exception à loguer, incluant la pile des appels</param>
            /// <param name="args">
            /// Tableau <see cref="Object"/> contenant zéro ou plusieurs objets à mettre en forme.
            /// </param>
            public static void Fatal(IFormatProvider provider, string format, Exception t, params object[] args)
            {
                if (provider == null) { Fatal(format, t, args); }
                else { Fatal(String.Format(provider, format, args), t); }
            }
            #endregion
        }
    }