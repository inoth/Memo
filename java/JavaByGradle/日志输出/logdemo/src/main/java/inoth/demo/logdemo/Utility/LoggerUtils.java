package inoth.demo.logdemo.Utility;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

public class LoggerUtils implements ILoggerUtils {

  public LoggerUtils(LogFileName fileName) {
    setLog(fileName.toString());
  }

  private Logger log;

  public void setLog(String log) {
    this.log = LoggerFactory.getLogger(log);
  }

  @Override
  public void info(String msg) {
    this.log.info(msg);
  }

  @Override
  public void error(String msg) {
    this.log.error(msg);
  }

  @Override
  public void error(String msg, Throwable err) {
    this.log.error(msg, err);
  }

}
