$(document).ready(function() {
    var claims = getClaimsJwt(localStorage.getItem("token")).permission;
    if (claims) {
        if (
          claims.includes("perm.product.delete") ||
          claims.includes("perm.product.update") ||
          claims.includes("perm.product.create") ||
          claims.includes("perm.product.read")
        ) {
          document.getElementById("footer-products").style.display = "block";
          if (claims.includes("perm.product.create")) {
            document.getElementById("create-products").style.display = "block";
          } else {
            document.getElementById("create-products").style.display = "none";
          }
          if (claims.includes("perm.product.update")) {
            document.getElementById("update-products").style.display = "block";
          } else {
            document.getElementById("update-products").style.display = "none";
          }
          if (claims.includes("perm.product.read")) {
            document.getElementById("search-products").style.display = "block";
          } else {
            document.getElementById("search-products").style.display = "none";
          }
        } else {
          document.getElementById("footer-products").style.display = "none";
        }
      }
});