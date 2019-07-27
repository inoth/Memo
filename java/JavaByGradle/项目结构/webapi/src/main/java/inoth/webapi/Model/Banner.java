package inoth.webapi.Model;

public class Banner {

  private long titid;
  private String titmsg;
  private String imgurl;
  private int state;
  private String scrurl;
  private int sort;
  private int pageno;

  public long getTitid() {
    return titid;
  }

  public void setTitid(long titid) {
    this.titid = titid;
  }

  public String getTitmsg() {
    return titmsg;
  }

  public void setTitmsg(String titmsg) {
    this.titmsg = titmsg;
  }

  public String getImgurl() {
    return imgurl;
  }

  public void setImgurl(String imgurl) {
    this.imgurl = imgurl;
  }

  public int getState() {
    return state;
  }

  public void setState(int state) {
    this.state = state;
  }

  public String getScrurl() {
    return scrurl;
  }

  public void setScrurl(String scrurl) {
    this.scrurl = scrurl;
  }

  public int getSort() {
    return sort;
  }

  public void setSort(int sort) {
    this.sort = sort;
  }

  public int getPageno() {
    return pageno;
  }

  public void setPageno(int pageno) {
    this.pageno = pageno;
  }
}
