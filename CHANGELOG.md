# Changelog
All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [5.7.0] - 2026-10-28
### Changed
- `DownloadFile(File)` with `Id` downloads from an address built from `Origin`/`FilesOrigin`; `File.Url` is ignored.
- `DownloadFile(File)` without `Id` sends the access token only if the scheme matches and the host is the `Origin`/`FilesOrigin` host or its parent domain (e.g. `pyrus.com`).
- `DownloadFile(File)` does not download link attachments (no size and MD5) and returns `ErrorCode.FileIsMissing`.
- Self-hosted with only `Origin` set: files are downloaded from `/services/attachment` on the `Origin` host.
- `UploadFile` and `DownloadFile(File)` choose between `Origin` and `FilesOrigin` by comparing them with the Pyrus defaults, not with the static `PyrusClient.Settings`.

## [2.1.14] - 2019-06-11
### Added
- This CHANGELOG file.
- added new error codes.
- schedule task to utc date with time.
- return decimal_places for form field number
- return task current step

### Changed
- Fixed closing file stream on retry
