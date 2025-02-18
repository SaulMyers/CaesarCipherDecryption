# Caesar Cipher Decryption

## Overview
* _Decrypter_: This is a class library that implements a method for decrypting a string that was previously encrypted with a Caesar Cipher.
* _CaesarCipherTestHarness_: A basic console application test harness.
* _DecrypterTestProject_: An Nunit based project that includes tests for the Decrypter library.

## What exactly does it do?
The Decrypter library only includes Caesar Cipher decryption currently but could be extended in the future to include encryption and other ciphers. It allows flexibility around the cipher offset and the maximum length of the string it can handle. 

The actual logic it implements is:

* For each character in the encrypted string:
  * Find the position of the encrypted character in the character set (i.e. the lowercase alphabet).
  * Use the character set to find the character 3 positions to the left of the position of the encrypted character, wrapping around to the end of the character set if our index is < 0 after decryption.
  * Record the decrypted character in the relevant position of the decrypted string result.
* Return the decrypted result.

## How to productionise it?
* Convert the Decrypter library to a nuget package and push it to the internal company repository so that it can be easily and safely shared across the company.
* There's not much point adding logging to such a simple helper class but performance monitoring (e.g. System.Diagnostics.Stopwatch) might be useful if it's used in applications where performance is critical.
* I'd revisit the error handling and implement a custom error for the scenario where the input string was longer than allowed.
* Allow for other character sets - the callers might want to use capital letters for example, and this could be configurable.
* Set up a CICD pipeline to compile and deploy it.
