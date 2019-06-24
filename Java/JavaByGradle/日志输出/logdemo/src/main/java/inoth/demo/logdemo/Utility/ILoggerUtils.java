package inoth.demo.logdemo.Utility;

public interface ILoggerUtils {
  void info(String msg);

  void error(String msg);

  void error(String msg, Throwable err);
}
