<?xml version="1.0"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
	<xsl:template match="/">
		
			<h1>Our Staff and Members</h1>
			<table border="1">
				<tr bgcolor="yellow"> 
					<td><b>Name </b></td> 
					<td><b>Role</b></td> 
				</tr>
				<xsl:for-each select="credentials/credential">
					<xsl:if test="Role != 'admin' and Role !='manager'">
						<tr style="font-size: 10pt; font-family: verdana">
							<td><xsl:value-of select="Username"/></td>							
							<td><xsl:value-of select="Role"/></td>
						</tr>
					</xsl:if>
				</xsl:for-each>
			</table>
		
	</xsl:template>
</xsl:stylesheet>
