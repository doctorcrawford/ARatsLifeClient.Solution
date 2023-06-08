// simple type just so we can intentionally catch it later
public class KylesCustomException : Exception {
  // forward on the incoming string to the base Exception class
  // this is inheritance
  public KylesCustomException(string kylesMsg) : base(kylesMsg) {

  }
}