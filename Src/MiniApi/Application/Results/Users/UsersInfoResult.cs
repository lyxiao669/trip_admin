namespace MiniApi.Application
{

  public class UsersInfoResult{
     public int Id { get; set; }
    /// <summary>
    /// 姓名
    /// </summary>
    public string UserName { get; set; }

    /// <summary>
    /// 密码
    /// </summary>
    public string Password { get; set; }
    /// <summary>
    /// 头像
    /// </summary>
    public string Avatar { get; set; }
  }
}