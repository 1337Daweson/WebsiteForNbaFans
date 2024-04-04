<template>
  <footer>
    <div class="footer-content">
      <p class="footer-p">
        © 2024 David Netušil, Vytvořeno pro účely bakalářské práce
      </p>
      <p class="footer-p">
        Sledujte nás na:
      </p>
      <ul>
        <li><a href="#">Twitter</a></li>
        <li><a href="#">Facebook</a></li>
        <li><a href="#">Instagram</a></li>
      </ul>
    </div>
  </footer>
</template>
   
   <script>

   </script>
   
  <style scoped>
  footer {
    display: flex;
    justify-content: center;
    align-items: center;
    background-color: #1c1f1c;
    height: 100px;
    width: 100%;
    color: white;
    font-size: 14px;
  }

  .footer-content {
    width: 80%;
    text-align: center;
  }

  .footer-content ul {
    list-style-type: none;
    padding: 0;
  }

  .footer-content ul li {
    display: inline;
    margin: 0 10px;
  }

  .footer-content ul li a {
    color: white;
    text-decoration: none;
  }

  .footer-p {
    color: white;
  }
</style>