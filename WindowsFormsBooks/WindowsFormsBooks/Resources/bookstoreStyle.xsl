<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
<xsl:template match="/">
<html> 
<body>
  <style>
    table {
    border-collapse: collapse; /* makes border between cells single*/
    }
    th, td {
    border: 1px solid black;
    padding: 10px;
    text-align: left;
    }
    li {
    list-style-type: none; /* removes markers */
    }
    ul {
    margin-left: 0; /* removes left and bottom indents in IE and Opera */
    margin-bottom: 0;
    padding-left: 0; /* removes left and bottom indents in Firefox, Safari, Chrome */
    padding-bottom: 0;
    }
  </style>
  <table>
    <tr bgcolor="#e0e0e0">
      <th style="text-align:center">Title</th>
      <th style="text-align:center">Author</th>
      <th style="text-align:center">Category</th>
      <th style="text-align:center">Year</th>
      <th style="text-align:center">Price</th>
    </tr>
    <xsl:for-each select="bookstore/book">
    <tr>
      <td><xsl:value-of select="title"/></td>
      <td>
        <ul>
          <xsl:for-each select="author">
            <li><xsl:value-of select="."/></li>
          </xsl:for-each>
        </ul>
      </td>
      <td><xsl:value-of select="@category"/></td>
      <td><xsl:value-of select="year"/></td>
      <td><xsl:value-of select="price"/></td>
    </tr>
    </xsl:for-each>
  </table>
</body>
</html>
</xsl:template>
</xsl:stylesheet>