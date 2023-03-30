# Text Encryption

This library can be used to generate a random key, encrypt a string of text and decrypt text using a key.

**Big scary warning**

I am NOT a security expert.  This library is a pet project and should NOT be considered a production worthy method for encrypting text for security purposes.


## Usage/Examples

### Generate a Random Key
```csharp
using TextEncryption;

// Create a OneTimePad object
OneTimePad onetimepad = new OneTimePad();

// Create a key by providing a desired length for the key.
// When encrypting text using a key using OneTimePad the key MUST be 
// at least as long as the text you want to encrypt
var key = onetimepad.GenerateKey(100);

```

### Encrypting Text
```csharp
using TextEncryption;

// Create a OneTimePad object
OneTimePad onetimepad = new OneTimePad();

string unencryptedText = "This is plain text you would like to encrypt";

// Generate a key (optional)
var key = onetimepad.GenerateKey(unencryptedText.length);

// Encrypt the text by passing in the text you want to encrypt and a
// key that contains, at a minimum, the same number of characters as 
// the unenecrypted text.
string encryptedText = onetimepad.Encrypt(unencryptedText, key);
```

### Decrypt Text
```csharp
using TextEncryption;

// Create a OneTimePad object
OneTimePad onetimepad = new OneTimePad();

string key = "Your key, which could be any string of text."; 

string encryptedText = ">1uB~H&O`@`i$;SMc530?s67/{4)m96`$O"iA8*ZAkw";

// Decrypt the text by passing in the encrypted text and the key
string unencryptedText = onetimepad.Decrypt(encryptedText, key);
```

### Note
All tabs, new lines, and returns are replaced with an empty string as text is encrypted.  Otherwise, most standard characters on a querty keyboard are supported.


## Authors

- [@ryancronrath](https://github.com/ryancronrath)


## License

[MIT](https://choosealicense.com/licenses/mit/)

