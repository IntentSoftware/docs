---
remarks: |
  Do not add any content to this file as any requests to this root path are redirected server side
  as per the `Documentation/Intent.Docs.sln` in the Intent Architect private repository. The
  <script> tag is for convenience when using `_build_and_serve.ps1`.

  If you are planning on adding content to this file, be aware there is an unresolved problem with
  viewing it. If one visits `https://intentarchitect.com/docs/`, then everything works fine, if one
  visits `https://intentarchitect.com/docs`, then all the relative paths on the published page stop
  working as the browser no longer sees the page as in a folder for things like the CSS ref.

  I tried using url rewrite in the web.config as per
  https://blog.elmah.io/web-config-redirects-with-rewrite-rules-https-www-and-more/, but that
  particular example didn't seem to work.

  I then tried using OWIN middleware, but even when debugging the Azure website, there was no
  discernible difference that I could see in the request context between `/docs` and `/docs/`.
  So for now the middleware does a redirect to the welcome page and then nothing looks scruffy
  to users who go to `/docs`.
---
<script type="text/javascript">
  window.location.href = "./articles/getting-started/welcome/welcome.html";
</script>
